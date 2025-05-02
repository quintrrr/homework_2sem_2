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

            var nodeLotteries = new TreeNode("Лотереи");
            foreach (var lottery in dataset.Lotteries ?? [])
            {
                var nodeLottery = new TreeNode(lottery.Name) { Tag = lottery };
                nodeLotteries.Nodes.Add(nodeLottery);
            }

            var nodeParticipants = new TreeNode("Участники");
            foreach (var participant in dataset.Participants ?? [])
            {
                var nodeParticipant = new TreeNode(participant.Name) { Tag = participant };  
                nodeParticipants.Nodes.Add(nodeParticipant);
            }
            

            var nodeTickets = new TreeNode("Билеты");
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

        private  void SaveToDb()
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
    }
}
