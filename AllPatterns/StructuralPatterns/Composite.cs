using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StructuralPatterns
{
    public class CompositeExample
    {
        public CompositeExample() { }
        public string forShow = "Occaecat irure commodo " +
            "labore ullamco est minim aute laborum sint officia " +
            "consequat cupidatat dolor reprehenderit. Nulla magna amet " +
            "aliqua incididunt laborum esse tempor aliqua ex esse veniam. " +
            "Proident tempor voluptate voluptate velit magna et eu aute sint " +
            "excepteur quis labore in. Sint consectetur sint aliquip minim " +
            "elit quis elit mollit voluptate sit aute " +
            "cupidatat. Anim eu Lorem aliqua elit enim " +
            "amet dolore tempor irure ullamco dolore " +
            "ad fugiat. Deserunt commodo aliquip " +
            "cillum exercitation exercitation ex velit " +
            "voluptate mollit sit aute" +
            ". Fugiat in officia amet est dolore " +
            "sunt. Pariatur amet qui esse fugiat veniam occaecat " +
            "Lorem exercitation consectetur qui. " +
            "Magna tempor exercitation laborum sunt minim magna " +
            "eu mollit laborum ut do sit";
        public void Show()
        {
            Text text = new Text(forShow);
            text.print();
        }
    }

   public abstract class Component
   {
        public abstract void add(Component component);
        public abstract string getText();
        public abstract void print();
   }

    //text
    //paragraphs
    //sentence
    public class Text : Component
    {
        List<Component> parapgraphs = new List<Component>();
        string text;
        public Text(string text)
        {
            this.text = text;
        }
        public override void add(Component component)
        {
            parapgraphs.Add(component);
        }

        public override string getText()
        {
            return text;
        }

        public override void print()
        {
            setComponents();
            for (int i= 0; i < parapgraphs.Count; i++){
                parapgraphs[i].print();
            }
        }

        private void setComponents()
        {
            string[] result = text.Split('\n');
            
            for(int i=0; i<result.Length; i++)
            {
                parapgraphs.Add(new Paragraph(result[i]));
            }
        }
    }

    public class Paragraph : Component
    { 
        List<Component> sentences = new List<Component>();
        string paragraph;
        public Paragraph(string paragraph) { this.paragraph = paragraph; }

        public override void add(Component component)
        {
            sentences.Add(component);
        }

        public override string getText()
        {
            return paragraph;
        }

        public override void print()
        {
            setComponents();
            for (int i = 0; i < sentences.Count; i++)
            {
                sentences[i].print();
            }
        }
        private void setComponents()
        {
            string[] result = paragraph.Split('\n');

            for (int i = 0; i < result.Length; i++)
            {
                sentences.Add(new Sentence(result[i]));
            }
        }
    }

    public class Sentence : Component //as leaf
    {
        string sentence;
        public Sentence(string text) => sentence = text;

        public override void add(Component component)
        {
            Console.WriteLine("Cannot add component");
        }

        public override string getText()
        {
            return sentence;
        }

        public override void print()
        {
            Console.WriteLine(getText());
        }
    }
}
