public static class GameManager
{
    public static int nbElfe{get;set;} = 0;
    public static int nbNinja{get;set;} = 0;
    public static int nbNoble{get;set;} = 0;
    public static int nbSauvage{get;set;} = 0;

    public static int Money{get;set;} = 10;

    public static void ResetCounter()
    {
        nbNinja = 0 ;
        nbElfe = 0 ;
        nbNoble = 0 ;
        nbSauvage = 0 ; 
    }

}