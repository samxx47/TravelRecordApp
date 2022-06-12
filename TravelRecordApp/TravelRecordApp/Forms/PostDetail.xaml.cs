using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
namespace TravelRecordApp.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetail : ContentPage
    {
        Post selectedPost;
        public PostDetail(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            experienceEntry.Text=selectedPost.Experience.ToString();
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);


                if (rows > 0)
                {
                    DisplayAlert("Updated", "experience succesfullt updated", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "experience failed to update", "OK");
                }

            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);


                if (rows > 0)
                {
                    DisplayAlert("Deleted", "experience succesfullt deleted", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "experience failed to delete   ", "OK");
                }

            }
        }
    }
}