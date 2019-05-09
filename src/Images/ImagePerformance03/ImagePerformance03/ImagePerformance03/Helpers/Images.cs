using System;
using Xamarin.Forms;

namespace ImagePerformance03.Helpers
{
    public class Images
    {
        static readonly Random random = new Random();

        public static ImageSource RandomSource()
        {
            return SourceById(random.Next(3));
        }

        public static ImageSource SourceById(int x)
        {
            switch (x)
            { 
                case 0:
                    return ImageSource.FromUri(new Uri("https://growtix-melupufoagt.stackpathdns.com/media/big//34/28/23/5a9f03c2-3734-4486-bd04-2d45ac1c102e.png"));
                case 1:
                    return ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Steven_Seagal_November_2016.jpg/230px-Steven_Seagal_November_2016.jpg"));
                case 2:
                    return ImageSource.FromUri(new Uri("https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cg_face%2Cq_80%2Cw_300/MTIwNjA4NjM0MDQyNzQ2Mzgw/hulk-hogan-9542305-1-402.jpg"));
                default:
                    throw new NotImplementedException($"Whoops {x} not implemented!");
            }
        }
    }
}