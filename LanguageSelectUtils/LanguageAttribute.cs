using System;
using LanguageSelectUitil;

namespace LanguageSelectUitils
{
    public class LanguageAttribute : Attribute
    {
        public LanguageEnum Language { get; private set; }

        public LanguageAttribute(LanguageEnum language)
        {
            Language = language;
        }
    }
}