using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using homework_2sem_2.DataAccess;
using homework_2sem_2.DataAccess.Models;
using homework_2sem_2.DataAccess.Repositories;

namespace homework_2sem_2
{
    public partial class MainForm : Form
    {
        private LotteryDataset? dataset;

        private readonly AppDbContext _dbContext;
        private readonly LotteryRepository lotteryRepository;
        private readonly ParticipantRepository participantRepository;
        private readonly TicketRepository ticketRepository;

        public MainForm(AppDbContext db)
        {
            _dbContext = db;
            lotteryRepository = new LotteryRepository(db);
            participantRepository = new ParticipantRepository(db);
            ticketRepository = new TicketRepository(db);

            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFiles.Filter = "json, xml|*.json; *.xml";
            if (openFiles.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                dataset = LotteryDataset.DeserializeData(openFiles.FileName);
                BuildTree();
                SaveToDb();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла: {ex.Message}");
            }
        }

        private void BuildTree()
        {
            if (dataset == null)
            {
                throw new Exception("Файл пустой");
            }

            entitiesTree.BeginUpdate();
            entitiesTree.Nodes.Clear();

            var nodeLotteries = new TreeNode("Лотереи") { Tag = "firstNode" };
            foreach (var lottery in dataset.Lotteries ?? [])
            {
                var nodeLottery = new TreeNode(lottery.Name) { Tag = lottery };
                nodeLotteries.Nodes.Add(nodeLottery);
            }

            var nodeParticipants = new TreeNode("Участники") { Tag = "firstNode" };
            foreach (var participant in dataset.Participants ?? [])
            {
                var nodeParticipant = new TreeNode(participant.Name) { Tag = participant };
                nodeParticipants.Nodes.Add(nodeParticipant);
            }


            var nodeTickets = new TreeNode("Билеты") { Tag = "firstNode" };
            foreach (var ticket in dataset.Tickets ?? [])
            {
                var nodeTicket = new TreeNode(String.Join(", ", ticket.Numbers)) { Tag = ticket };
                nodeTickets.Nodes.Add(nodeTicket);
            }

            entitiesTree.Nodes.Add(nodeLotteries);
            entitiesTree.Nodes.Add(nodeParticipants);
            entitiesTree.Nodes.Add(nodeTickets);
            entitiesTree.EndUpdate();
        }

        private void SaveToDb()
        {
            if (dataset == null)
            {
                return;
            }

            using var tx = _dbContext.Database.BeginTransaction();

            try
            {
                lotteryRepository.AddLotteries(dataset.Lotteries ?? []);
                participantRepository.AddParticipants(dataset.Participants ?? []);
                ticketRepository.AddTickets(dataset.Tickets ?? []);
                tx.Commit();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show($"Не удалось связаться с базой данных: {ex.Message}");
            }
        }

        private void entitiesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = e.Node;
            while (selectedNode != null && selectedNode.Tag != (object)"firstNode")
            {
                selectedNode = selectedNode.Parent;
            }

            switch (selectedNode?.Text)
            {
                case "Лотереи":
                    infoTable.Tag = typeof(Lottery);
                    infoTable.DataSource = dataset?.Lotteries
                        .Select(l => new
                        {
                            l.Id,
                            l.Name,
                            l.PrizeFund,
                            l.NumberRange.Min,
                            l.NumberRange.Max,
                            l.NumberRange.NumbersPerTicket,
                            l.DrawTime,
                            l.TicketPrice,
                            WinningCombination = String.Join(",", l.WinningCombination),
                        }).ToList();
                    break;
                case "Участники":
                    infoTable.Tag = typeof(Participant);
                    infoTable.DataSource = dataset?.Participants
                        .Select(p => new
                        {
                            p.Id,
                            p.Name,
                            p.BirthDate,
                            p.ContactInfo.Phone,
                            p.ContactInfo.Email,
                            p.ContactInfo.Address,
                        }).ToList();
                    break;
                case "Билеты":
                    infoTable.DataSource = dataset?.Tickets
                        .Select(t => new
                        {
                            t.Id,
                            t.IsWinning,
                            t.PurchaseInfo.Date,
                            t.PurchaseInfo.PurchaseNumber,
                            t.LotteryId,
                            t.OwnerId,
                            Numbers = String.Join(",", t.Numbers),
                        }).ToList();

                    infoTable.Tag = typeof(Ticket);
                    break;
            }

        }

        private void infoTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        { 
            if (infoTable.DataSource == null)
            {
                return;
            }
            var tag = infoTable.Tag as Type;
            foreach (DataGridViewColumn col in infoTable.Columns)
            {
                switch (col.Name)
                {
                    case "Name":
                        if (tag == typeof(Lottery))
                        {
                            col.HeaderText = "Название";
                        }
                        else if (tag == typeof(Participant))
                        {
                            col.HeaderText = "Имя";
                        }
                        break;
                    case "TicketPrice":
                        col.HeaderText = "Цена билета";
                        break;
                    case "DrawTime":
                        col.HeaderText = "Время розыгрыша";
                        break;
                    case "PrizeFund":
                        col.HeaderText = "Призовой фонд";
                        break;
                    case "BirthDate":
                        col.HeaderText = "Дата рождения";
                        break;
                    case "IsWinning":
                        col.HeaderText = "Победный";
                        break;
                    case "LotteryId":
                        col.HeaderText = "Id Лотереи";
                        break;
                    case "OwnerId":
                        col.HeaderText = "Id Владельца";
                        break;
                    case "WinningCombination":
                        col.HeaderText = "Победная комбинация";
                        break;
                    case "Min":
                        col.HeaderText = "Минимальное число";
                        break;
                    case "Max":
                        col.HeaderText = "Максимальное число";
                        break;
                    case "NumbersPerTicket":
                        col.HeaderText = "Чисел на билете";
                        break;
                    case "Phone":
                        col.HeaderText = "Телефон";
                        break;
                    case "Address":
                        col.HeaderText = "Адрес";
                        break;
                    case "Numbers":
                        col.HeaderText = "Числа";
                        break;
                    case "Date":
                        col.HeaderText = "Дата покупки";
                        break;
                    case "PurchaseNumber":
                        col.HeaderText = "Номер покупки";
                        break;
                   
                }
            }
        }
    }
}
