using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test.Controls;
using Xamarin.Forms;

namespace Test
{
    public class TestViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public System.Collections.ObjectModel.ObservableCollection<GalleryImage> Images { get; set; }
        

        public TestViewModel()
        {
            this.Images = new System.Collections.ObjectModel.ObservableCollection<GalleryImage>();
            load();

        }

        public async void load()
        {
            await Task.Delay(10000);

            this.Images.Add(new GalleryImage()
            {
                Source = "http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png"
            });
            this.Images.Add(new GalleryImage()
            {
                Source = "http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png"
            });
            this.Images.Add(new GalleryImage()
            {
                Source = "http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png"
            });
            this.Images.Add(new GalleryImage()
            {
                Source = "http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png"
            });
            this.Images = new System.Collections.ObjectModel.ObservableCollection<GalleryImage>(this.Images);
            this.NotifyPropertyChanged("Images");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            //this.Images.Add("http://www.fmwconcepts.com/misc_tests/anaglyph/lena_anaglyph.png");
            //this.Images.Add("http://www.wptouch.com/wp-content/themes/wptouch4site/img/extensions/power-pack/responsive.jpg");
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
