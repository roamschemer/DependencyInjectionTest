using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionTest {

    class Program {
        static void Main(string[] args) {
            var vTubers = new List<VTuber>(){
                new VTuber("林檎", "九条", "貴族"),
                new VTuber("棗", "九条", "貴族"),
                new VTuber("茘枝", "九条", "貴族"),
                new VTuber("杏子", "九条", "貴族"),
                new VTuber("ユイ", "結目", "芸人"),
                new VTuber("しあ", "水瀬", "陰キャ"),
                new VTuber("もなか", "巻乃", "ヤンデレ"),
                new VTuber("調", "泡沫", "王族"),
                new VTuber("ローズ", "青咲", "園長"),
                new VTuber("ミュウミュウ", "幸糖", "芸人"),
                new VTuber("クロミ", "白乃", "暗殺者"),
                new VTuber("ふうか", "紫吹", "アイドル"),
                new VTuber("なな", "菜花", "癒し"),
                new VTuber("スキア", "碧惺", "鉱石"),
                new VTuber("笑虹", "雨ヶ崎", "アイドル"),
                new VTuber("ひなた", "白石", "芸人"),
                new VTuber("そにあ", "三田", "衛兵"),
                new VTuber("うか", "縁", "神"),
                new VTuber("らみょん", "都三代", "芸人"),
            };
            var vTuberGroup = new VTuberGroup("Avatar2.0 Project", vTubers);
            var vTuberFestival = new VTuberFestival("Avatar2.0 Project 単独ライブイベント", vTuberGroup);
            foreach (var _ in Enumerable.Range(0, 9)) {
                Console.WriteLine(vTuberFestival.Introductory());
            }
        }
    }

    public class VTuber {
        public string FastName { get; }
        public string LastName { get; }
        public string Attribute { get; }
        public VTuber(string fastName, string lastName, string attribute) {
            FastName = fastName;
            LastName = lastName;
            Attribute = attribute;
        }
        public string FullName() => $"{LastName} {FastName}";
    }

    public interface IVTuberGroup {
        public VTuber GetRandomVTuber();
    }

    public class VTuberGroup : IVTuberGroup {
        public string Name { get; }
        public List<VTuber> VTubers { get; }
        public VTuberGroup(string name, List<VTuber> vTuber) {
            Name = name;
            VTubers = vTuber;
        }
        /// <summary>ランダムで一人選ぶ</summary>
        /// <returns>VTuber</returns>
        public VTuber GetRandomVTuber() {
            if (VTubers == null) return null;
            var rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            return VTubers[rnd.Next(0, VTubers.Count)];
        }
    }

    public class VTuberFestival {
        public string Name { get; }
        public IVTuberGroup VTuberGroup { get; }
        public VTuberFestival(string name, IVTuberGroup vTuberGroup) {
            Name = name;
            VTuberGroup = vTuberGroup;
        }
        /// <summary>
        /// ランダムで選ばれた人物の紹介文を返す。
        /// </summary>
        /// <returns>紹介文</returns>
        public string Introductory() {
            var vtuber = VTuberGroup.GetRandomVTuber();
            var honorifics = new[] { "貴族", "王族", "神" };
            if (honorifics.Contains(vtuber.Attribute)) {
                return $"{vtuber.FullName()} 様にきていただきました！";
            }
            return $"{vtuber.FullName()} ちゃんがきてくれたぞ！";
        }
    }


}
