using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerativePatterns
{
    class Foundation { public string Type {  get; set; } }
    class Lips { public string Type {  get; set; } }
    class Eyes { public string Type { get; set; } }

   class BeautyBox
   {
        public string Type { get; set; }
        public Foundation Foundation { get; set; }
        public Lips Lips { get; set; }
        public Eyes Eyes { get; set; }
        public void ShowInfo() =>
            Console.WriteLine
                ($"BB Type: {Type}, Foundation: {Foundation.Type}, " +
                $"Lips: {Lips.Type}, Eyes: {Eyes.Type}");
   }
    abstract class BeautyBoxBuilder
    {
        public BeautyBox BeautyBox { get; set; }
        public void CreateBeautyBox()
        {
            BeautyBox = new BeautyBox();
        }
        public abstract void SetType();
        public abstract void SetFoundation();
        public abstract void SetLips();
        public abstract void SetEyes();
    }

    class LuxuryBeautyBoxBuilder : BeautyBoxBuilder
    {
        public override void SetType()
        {
            BeautyBox.Type = "Luxury";
        }

        public override void SetEyes()
        {
            BeautyBox.Eyes = new Eyes { Type = "Mascara"};
        }

        public override void SetFoundation()
        {
            BeautyBox.Foundation = new Foundation { Type = "Cream" };
        }

        public override void SetLips()
        {
            BeautyBox.Lips= new Lips { Type = "Gloss" };
        }
    }

    class SimpleBeautyBoxBuilder : BeautyBoxBuilder
    {
        public override void SetType()
        {
            BeautyBox.Type = "Simple";
        }

        public override void SetEyes()
        {
            BeautyBox.Eyes = new Eyes { Type = "Eyeshadows" };
        }

        public override void SetFoundation()
        {
            BeautyBox.Foundation = new Foundation { Type = "Fluid" };
        }

        public override void SetLips()
        {
            BeautyBox.Lips = new Lips { Type = "Hygienic lipstick" };
        }
    }

    class CheapBeautyBoxBuilder : BeautyBoxBuilder
    {
        public override void SetType()
        {
            BeautyBox.Type = "Cheap";
        }

        public override void SetEyes()
        {
            BeautyBox.Eyes = new Eyes { Type = "No" };
        }

        public override void SetFoundation()
        {
            BeautyBox.Foundation = new Foundation { Type = "Fluid" };
        }

        public override void SetLips()
        {
            BeautyBox.Lips = new Lips { Type = "Hygienic lipstick" };
        }
    }

    class BuilderClient
    {
        public static BeautyBox GetBeautyBox(BeautyBoxBuilder builder)
        {
            builder.CreateBeautyBox();
            builder.SetType();
            builder.SetFoundation();
            builder.SetEyes();
            builder.SetLips();
            return builder.BeautyBox;
        }


        public static void Demonstrate()
        {
            BeautyBoxBuilder builder = new LuxuryBeautyBoxBuilder();
            BeautyBox luxuryBox = GetBeautyBox(builder);
            luxuryBox.ShowInfo();

            builder = new CheapBeautyBoxBuilder();
            BeautyBox cheapBox = GetBeautyBox(builder);
            cheapBox.ShowInfo();
        }
    }

}
