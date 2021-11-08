using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var MyPeople = new PeopleEntities().People;

            foreach(Person item in MyPeople)
            {
                listBox1.Items.Add(item);
            }

            listBox1.SelectedIndexChanged += new EventHandler(people_SelectedIndexChanged);

        }

        private void people_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox ListofPeople = sender as ListBox;
            Person SelectedPerson = ListofPeople.SelectedItem as Person;

            listBox2.Items.Add($"{SelectedPerson.name} {SelectedPerson.surname}");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new PeopleEntities())
            {
                var newperson = new Person {name = textBox1.Text, surname = textBox2.Text} ;
                context.People.Add(newperson);
                context.SaveChanges();
            }
        }
    }

    public partial class Person
    {
        public override string ToString()
        {
            return $"{name} {surname}";
        }

    }

}
