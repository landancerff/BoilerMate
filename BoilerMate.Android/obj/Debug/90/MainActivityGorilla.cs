
using System;
using Xamarin.Forms;

namespace BoilerMate.Droid
{
    public partial class MainActivity
    {
        private readonly string ___Gorilla_ServerName = "Good Gorilla";
        private readonly string[] ___Gorilla_Assemblies = new string[] { "BoilerMate.Android", "BoilerMate" };

        private new void LoadApplication(Xamarin.Forms.Application app)
        {
            var assemblies = new System.Reflection.Assembly[___Gorilla_Assemblies.Length];

            for (var i = 0; i < ___Gorilla_Assemblies.Length; i++)
            {
                try
                {
                    assemblies[i] = System.Reflection.Assembly.Load(___Gorilla_Assemblies[i]);

                    if (assemblies[i] == null)
                    {
                        System.Diagnostics.Debug.WriteLine("[Gorilla] Assembly '{0}' not found.", ___Gorilla_Assemblies[i]);
                    }

                }
                catch (System.Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("[Gorilla] Exception occurred while obtaining assembly {0}. {1}{2}", ___Gorilla_Assemblies[i], e.Message, e.StackTrace);
                }
            }

            base.LoadApplication(
                UXDivers.Gorilla.Droid.Player.UseApplication(app,
                        this,
                        new UXDivers.Gorilla.Config(___Gorilla_ServerName).RegisterAssemblies(assemblies)));
        }


        private readonly static Android.Views.GestureDetector LongPressDetector = new Android.Views.GestureDetector(new UXDivers.Gorilla.Droid.LongPressGestureListener());

        public override bool DispatchTouchEvent(Android.Views.MotionEvent ev)
        {
            LongPressDetector.OnTouchEvent(ev);

            return base.DispatchTouchEvent(ev);
        }

        public override bool OnKeyUp(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if ((keyCode == Android.Views.Keycode.F1 || keyCode == Android.Views.Keycode.Menu || keyCode == Android.Views.Keycode.VolumeUp || keyCode == Android.Views.Keycode.VolumeDown || keyCode == Android.Views.Keycode.VolumeMute) && UXDivers.Gorilla.Coordinator.Instance != null) 
            {  
                UXDivers.Gorilla.ActionManager.ShowMenu();
                return true; 
            } 

            return base.OnKeyUp(keyCode, e);
        }
    }
}
