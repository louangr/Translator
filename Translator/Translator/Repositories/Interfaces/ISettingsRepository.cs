namespace Translator.Repositories.Interfaces
{
    public interface ISettingsRepository
    {
        string SourceTranslationLanguage { get; set; }
        string TargetTranslationLanguage { get; set; }
    }
}