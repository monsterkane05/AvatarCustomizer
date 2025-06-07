namespace AvatarCustomiser;

public class ContentResolver
{
    private string projectRoot = Directory.GetCurrentDirectory();
    
    
    public string GetUpper(int index)
    {
        switch (index)
        {
            case 0:
                return  $"{projectRoot}/Resources/Upper/Shirt-Red.png";
            case 1:
                return  $"{projectRoot}/Resources/Upper/Shirt-Boiler.png";
            default:
                throw new Exception("Invalid Upper Index");
        }
    }
    
    public string GetLower(int index)
    {
        switch (index)
        {
            case 0:
                return  $"{projectRoot}/Resources/Lower/Shorts-Blue.png";
            default:
                throw new Exception("Invalid Lower Index");
        }
    }
    
    public string GetBackground(int index)
    {
        switch (index)
        {
            case 0:
                return  $"{projectRoot}/Resources/Background/Background-Grey.png";
            case 1:
                return $"{projectRoot}/Resources/Background/Background-Rare.png";
            default:
                throw new Exception("Invalid Background Index");
        }
    }
    
    public string GetBody(int index)
    {
        switch (index)
        {
            case 0:
                return  $"{projectRoot}/Resources/Bodys/Body-White.png";
            case 1:
                return $"{projectRoot}/Resources/Bodys/Body-Brown.png";
            default:
                throw new Exception("Invalid Body Index");
        }
    }
}