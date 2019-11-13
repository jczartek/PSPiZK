using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;
using Android.Content;
using Android.Preferences;

namespace Kolory
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView etykieta_panel;
        private SeekBar seekBarR, seekBarG, seekBarB; //TrackBar
        private Spinner spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            etykieta_panel = FindViewById<TextView>(Resource.Id.etykieta_panel);
            seekBarR = FindViewById<SeekBar>(Resource.Id.seekBarR);
            seekBarG = FindViewById<SeekBar>(Resource.Id.seekBarG);
            seekBarB = FindViewById<SeekBar>(Resource.Id.seekBarB);

            seekBarR.ProgressChanged += seekBar_ProgressChanged;
            seekBarG.ProgressChanged += seekBar_ProgressChanged;
            seekBarB.ProgressChanged += seekBar_ProgressChanged;

            //zmiana wyglądu suwaków
            float promień = 16;
            float[] promienie = new float[] { promień, promień, promień, promień, promień, promień, promień, promień };
            RoundRectShape rrs = new RoundRectShape(promienie, null, null);

            ShapeDrawable sdR = new ShapeDrawable(rrs);
            sdR.Paint.SetShader(new LinearGradient(0, 0, 400, 0, Color.White, Color.Red, Shader.TileMode.Clamp));
            seekBarR.ProgressDrawable = sdR;

            ShapeDrawable sdG = new ShapeDrawable(rrs);
            sdG.Paint.SetShader(new LinearGradient(0, 0, 400, 0, Color.White, Color.Green, Shader.TileMode.Clamp));
            seekBarG.ProgressDrawable = sdG;

            ShapeDrawable sdB = new ShapeDrawable(rrs);
            sdB.Paint.SetShader(new LinearGradient(0, 0, 400, 0, Color.White, Color.Blue, Shader.TileMode.Clamp));
            seekBarB.ProgressDrawable = sdB;

            //rozwijana lista
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            //spinner.SetBackgroundColor(Color.White);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.kolory, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.ItemSelected += spinner_ItemSelected;

            odtwórzStan();
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch(e.Position)
            {
                case 0:
                    break;
                case 1:
                    seekBarR.Progress = 0;
                    seekBarG.Progress = 0;
                    seekBarB.Progress = 0;
                    break;
                case 2:
                    seekBarR.Progress = 255;
                    seekBarG.Progress = 255;
                    seekBarB.Progress = 255;
                    break;
            }
        }

        private void seekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            //etykieta_panel.SetBackgroundColor(Color.CornflowerBlue);

            int r = seekBarR.Progress;
            int g = seekBarG.Progress;
            int b = seekBarB.Progress;

            float[] hsvComponents = { 0f, 0f, 0f };
            Color.RGBToHSV(r, g, b, hsvComponents);

            string rgb = "#" +
                r.ToString("X2").ToUpper() +
                g.ToString("X2").ToUpper() +
                b.ToString("X2").ToUpper();
            string hsv =
                (Java.Lang.Math.Round(100 * hsvComponents[0]) / 100f).ToString() + " " +
                (System.Math.Round(100 * hsvComponents[1]) / 100).ToString() + " " +
                (System.Math.Round(100 * hsvComponents[2]) / 100).ToString();

            etykieta_panel.SetBackgroundColor(Color.Argb(255, r, g, b));
            etykieta_panel.Text = this.GetString(Resource.String.etykieta) + ":\nRGB: " + rgb + "\nHSV: " + hsv;

            //int jasność = (r + g + b) / 3;
            int jasność = (int)(0.2*r + 0.7*g + 0.1*b);
            //if (jasność > 127) etykieta_panel.SetTextColor(Color.Black);
            //else etykieta_panel.SetTextColor(Color.White);
            etykieta_panel.SetTextColor((jasność > 127) ? Color.Black : Color.White);

            spinner.SetSelection(0);
        }

        private const string składowaR = "SkładowaR";
        private const string składowaG = "SkładowaG";
        private const string składowaB = "SkładowaB";

        #region Ustawienia
        private void zapiszStan()
        {
            ISharedPreferencesEditor edytorUstawień = PreferenceManager.GetDefaultSharedPreferences(this).Edit();
            edytorUstawień.PutInt(składowaR, seekBarR.Progress);
            edytorUstawień.PutInt(składowaG, seekBarG.Progress);
            edytorUstawień.PutInt(składowaB, seekBarB.Progress);
            edytorUstawień.Commit();
        }

        private bool odtwórzStan()
        {
            ISharedPreferences ustawienia = PreferenceManager.GetDefaultSharedPreferences(this);
            seekBarR.Progress = ustawienia.GetInt(składowaR, 0);
            seekBarG.Progress = ustawienia.GetInt(składowaG, 0);
            seekBarB.Progress = ustawienia.GetInt(składowaB, 0);
            return
                ustawienia.Contains(składowaR) &&
                ustawienia.Contains(składowaG) &&
                ustawienia.Contains(składowaB);
        }
        #endregion

        protected override void OnPause()
        {
            base.OnPause();
            zapiszStan();
        }
    }
}