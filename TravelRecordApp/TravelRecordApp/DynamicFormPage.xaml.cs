using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicFormPage : ContentPage
    {
        List<PageMetadata> pageMetadatas = new List<PageMetadata>();
        //VenueLogic venues = VenueLogic.GetVenus();
        StackLayout stack = new StackLayout();
        public DynamicFormPage()
        {
            InitializeComponent();
            Content = GetDynamicForm();

        }



        public StackLayout GetDynamicForm()
        {
            PageMetadata pageMetaData1 = new PageMetadata();
            pageMetaData1.Title = "title1";
            pageMetaData1.ControlType = "Entry";
            pageMetaData1.cssClass = "cssClass1";
            pageMetadatas.Add(pageMetaData1);

            PageMetadata pageMetaData2 = new PageMetadata();
            pageMetaData2.Title = "title1";
            pageMetaData2.ControlType = "Entry";
            pageMetaData2.cssClass = "cssClass2";
            pageMetadatas.Add(pageMetaData2);

            PageMetadata pageMetaData3 = new PageMetadata();
            pageMetaData3.Title = "title1";
            pageMetaData3.ControlType = "Dropdown";
            pageMetaData3.cssClass = "cssClass1";
            pageMetadatas.Add(pageMetaData3);


            PageMetadata pageMetaData4 = new PageMetadata();
            pageMetaData4.Title = "title1";
            pageMetaData4.ControlType = "Dropdown";
            pageMetaData4.cssClass = "cssClass1";
            pageMetadatas.Add(pageMetaData4);
           
            foreach (var item in pageMetadatas)
            {
                switch (item.ControlType)
                {
                    case "Entry":
                        stack.Children.Add(new Entry { Placeholder = item.Title, Text = "sometext" });
                        var e = new Entry { Text = "value" };
                        break;

                    case "Dropdown":
                        stack.Children.Add(new Label { Text="label Created Dynamically" });
                        break;
                    default:
                        break;
                }
            }
            return stack;

        }


        private void ToolbarItem_Clicked_dynamic(object sender, EventArgs e)
        {
            var temp = stack.Children.OfType<Entry>().FirstOrDefault();
            Post post = new Post()
            {
                Experience = temp.Text
           };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);


                if (rows > 0)
                {
                    DisplayAlert("Success", "experience succesfullt added", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "experience failed to added", "OK");
                }

            }
        }
    }
}