PasswordCombos combos = new PasswordCombos();
combos.WriteAllCombsToFile("Passwords.txt", 4);

public class PasswordCombos
{
    public char[] combination;
    public static char[] PASSWORDCHARACTERS = "abcdefghijklmnopqrstuvwxyz0123456789!#$*-.@_~".ToCharArray();
    //BASE
    public void AllCombs(int length, string start = null)
    {

        combination = new char[length];
        combination[0] = PASSWORDCHARACTERS[0];

        for(int j = 1; j < length; j++)
            combination[j] = '\0';

        if(start != null)
            for(int p = 0; p < start.Length; p++)
                combination[p] = start[p];

        int i;
        int[] index = new int[length];

        //Stops when the code tries to access an index higher than the length
        try
        {
            while (true)
            {
                i = 0;
                while (true)
                {
                    index[i]++;
                    if(index[i] < PASSWORDCHARACTERS.Length)
                    {
                        combination[i] = PASSWORDCHARACTERS[index[i]];
                        break;
                    } 
                    combination[i] = PASSWORDCHARACTERS[0];
                    index[i] = 0;
                    i++;
                    
                }
            }
        }
        catch
        {
            Console.Write("Its all done");
        }
    }
    //In this example, I am using StreamWriter to write the combinations to a file up to the max length stated
    public void WriteAllCombsToFile(string path, int length, string start = null)
    {

        StreamWriter sw = new StreamWriter(path);
        combination = new char[length];
        combination[0] = PASSWORDCHARACTERS[0];

        for(int j = 1; j < length; j++)
            combination[j] = '\0';
        

        if(start != null)
            for(int p = 0; p < start.Length; p++)
                combination[p] = start[p];
        

        int i;
        int[] index = new int[length];
        //Stops when the code tries to access an index higher than the length
        try
        {
            using (sw)
                while (true)
                {
                    i = 0;
                    while (true)
                    {

                        sw.WriteLine(new string(combination));
                        index[i]++;
                        if(index[i] < PASSWORDCHARACTERS.Length)
                        {
                            combination[i] = PASSWORDCHARACTERS[index[i]];
                            break;
                        } 
                        combination[i] = PASSWORDCHARACTERS[0];
                        index[i] = 0;
                        i++;  
                    }
                }
        }
        catch
        {
            Console.Write("Its all done");
        }
    }
}