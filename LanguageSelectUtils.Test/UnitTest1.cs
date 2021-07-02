using FluentAssertions;
using LanguageSelectUitil;
using LanguageSelectUitils;
using NUnit.Framework;

namespace LanguageSelectUtils.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetNameTest()
        {
            var fakeLeagueModel = new FakeLeagueModel
            {
                LeagueId = 123456,
                LeagueNameCh = "中文",
                LeagueNameCn = "简中",
                LeagueNameEn = "English"
            };

            fakeLeagueModel.GetName(LanguageEnum.Ch).Should().BeEquivalentTo("中文");
            fakeLeagueModel.GetName(LanguageEnum.Cn).Should().BeEquivalentTo("简中");
            fakeLeagueModel.GetName(LanguageEnum.En).Should().BeEquivalentTo("English");
        }
        
        /// <summary>
        /// 當指定的 language抓不到的時候，回傳 default language
        /// </summary>
        [Test]
        public void GetNameChTest()
        {
            var fakeLeagueModel = new FakeLeagueModel
            {
                LeagueId = 123456,
                LeagueNameCh = "",
                LeagueNameCn = "简中",
                LeagueNameEn = "English"
            };

            fakeLeagueModel.GetName(LanguageEnum.Ch).Should().BeEquivalentTo("English");

        }
    }


    public class FakeLeagueModel
    {
        public int LeagueId { get; set; }
        [Language(LanguageEnum.Ch)]
        public string LeagueNameCh { get; set; }
        [Language(LanguageEnum.Cn)]
        public string LeagueNameCn { get; set; }
        [Language(LanguageEnum.En)]
        public string LeagueNameEn { get; set; }
    }
    
}