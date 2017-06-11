using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AndroidApp
{
    [Activity(Label = "MediaPlayerActivity")]
    public class MediaPlayerActivity : AppCompatActivity
    {
        Button playButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MediaPlayer);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            playButton = FindViewById<Button>(Resource.Id.playButton);
            playButton.Click += PlayButton_Click;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            var player = Android.Media.MediaPlayer.Create(this, Resource.Raw.helloWorld);
            player.Start();
        }
    }
}