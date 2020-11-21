public interface ISaveLoadVisiter
{
    void Save(SkinSaved skinSaved);
    SkinSaved Load(SkinSaved shopSaved);
}
