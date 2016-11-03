using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Test.Controls
{
    public partial class ImageGallery : ScrollView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(ObservableCollection<GalleryImage>), typeof(ImageGallery), null, propertyChanged: ItemsChanged);

        public static readonly BindableProperty HasUploadButtonProperty = BindableProperty.Create(nameof(HasUploadButton), typeof(bool), typeof(ImageGallery), false);

        public static readonly BindableProperty UploadButtonImageProperty = BindableProperty.Create(nameof(UploadButtonImage), typeof(string), typeof(ImageGallery), null);

        public ObservableCollection<GalleryImage> ItemsSource
        {
            get
            {
                return (ObservableCollection<GalleryImage>)this.GetValue(ItemsSourceProperty);
            }
            set
            {
                this.SetValue(ItemsSourceProperty, (object)value);
            }
        }

        public bool HasUploadButton
        {
            get
            {
                return (bool)this.GetValue(HasUploadButtonProperty);
            }
            set
            {
                this.SetValue(HasUploadButtonProperty, (bool)value);
            }
        }

        public string UploadButtonImage
        {
            get
            {
                return (string)this.GetValue(UploadButtonImageProperty);
            }
            set
            {
                this.SetValue(UploadButtonImageProperty, (string)value);
            }
        }

        public int Rows { get; set; }

        private List<GalleryImage> Images { get; set; }

        private int lastItemRowIndex { get; set; }

        private bool isFirstSizeChange { get; set; }

        private int ShowingImagesStep { get; set; }

        private int hiddenImagePartWidth { get; set; }

        private double ImageSize { get; set; }

        public ImageGallery()
        {
            InitializeComponent();
            this.StyleImageGallery();
            this.InitializeVariables();
        }

        private void StyleImageGallery()
        {
            this.Orientation = ScrollOrientation.Horizontal;
            this.HorizontalOptions = new LayoutOptions()
            {
                Alignment = LayoutAlignment.Fill,
                Expands = true
            };
        }

        private void InitializeVariables()
        {
            this.isFirstSizeChange = true;
            this.ShowingImagesStep = 0;
            this.lastItemRowIndex = 0;
            this.Images = new List<GalleryImage>();

            this.SizeChanged += ImageGallery_SizeChanged;
            this.Scrolled += ImageGallery_Scrolled;
        }

        private void Initialize()
        {
            this.hiddenImagePartWidth = 0;

            var hasScroll = this.ItemsSource.Count > this.Rows * this.Rows;
            if (hasScroll)
            {
                this.hiddenImagePartWidth = 10;
            }

            var enumerator = ItemsSource.GetEnumerator();
            while (enumerator.MoveNext())
            {
                this.Images.Add(enumerator.Current);
            }

            this.AddFirstScreenImages();
        }

        private void CreateRows()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                this.GalleryContainer.Children.Add(new GalleryRow(this.ImageSize));
            }
        }

        private void AddFirstScreenImages()
        {
            //TODO: refactor this code
            var imagesCount = this.Rows * this.Rows;

            if (this.HasUploadButton)
            {
                if (this.Images.Count >= imagesCount)
                {
                    this.AddUploadButton(0);
                }
            }

            this.AddImagesToGallery(imagesCount, 0);
            this.ShowingImagesStep = this.Rows;

            if (this.HasUploadButton)
            {
                if (this.Images.Count < imagesCount)
                {
                    var rowIndex = lastItemRowIndex + 1;
                    if (rowIndex == this.Rows)
                    {
                        rowIndex = 0;
                    }

                    this.AddUploadButton(rowIndex);
                }
            }
        }

        private void AddImagesToGallery(int take, int skip)
        {
            var galleryRows = this.GalleryContainer.Children;
            var images = this.Images.Skip(skip).Take(take);

            for (int i = 0; i < images.Count(); i++)
            {
                var currentGalleryRowIndex = i % Rows;
                if (currentGalleryRowIndex >= galleryRows.Count)
                {
                    return;
                }

                var currenGalleryRow = (galleryRows[currentGalleryRowIndex] as GalleryRow);
                var image = images.ElementAt(i);

                image.WidthRequest = ImageSize;
                image.HeightRequest = ImageSize;


                currenGalleryRow.Children.Add(image);
                this.lastItemRowIndex = currentGalleryRowIndex;
            }
        }

        private void AddAdditionalImages()
        {
            var imageCount = this.Rows;
            var skip = this.ShowingImagesStep * this.Rows;
            this.AddImagesToGallery(imageCount, skip);
            this.ShowingImagesStep++;
        }

        private void ImageGallery_SizeChanged(object sender, EventArgs e)
        {
            //if gallery is empty, this is the first invocation of method
            if (isFirstSizeChange)
            {
                this.isFirstSizeChange = false;
                var imageGallery = (sender as ImageGallery);
                var screenSize = imageGallery.Width;

                //set image size to screem size and rows=colums
                this.ImageSize = screenSize / this.Rows + hiddenImagePartWidth;

                this.CreateRows();
            }
        }

        private void ImageGallery_Scrolled(object sender, ScrolledEventArgs e)
        {
            var pixelsBeforeEnd = 80;
            var positionForAdding = this.ContentSize.Width - this.Width - pixelsBeforeEnd;
            if (this.ScrollX >= positionForAdding)
            {
                AddAdditionalImages();
            }
        }

        private void AddUploadButton(int rowIndex)
        {
            var galleryRows = this.GalleryContainer.Children;
            if (!galleryRows.Any())
            {
                return;
            }

            var lastGalleryRow = (galleryRows[rowIndex] as GalleryRow);
            lastGalleryRow.Children.Add(new UploadButton()
            {
                Source = this.UploadButtonImage,
                WidthRequest = ImageSize,
                HeightRequest = ImageSize
            });
        }

        private static void ItemsChanged(object bindable, object oldValue, object newValue)
        {
            var imageGallery = (bindable as ImageGallery);
            imageGallery.Initialize();
        }
    }

    public class GalleryRow : StackLayout
    {
        public GalleryRow(double heigth)
        {
            this.HeightRequest = heigth;
            this.Spacing = 0;
            this.Orientation = StackOrientation.Horizontal;
        }
    }

    public class GalleryImage : Image
    {
        public GalleryImage()
        {
            this.Aspect = Aspect.Fill;
        }
    }

    public class UploadButton : Image
    {
        public UploadButton()
        {
            this.Aspect = Aspect.Fill;
        }
    }
}
