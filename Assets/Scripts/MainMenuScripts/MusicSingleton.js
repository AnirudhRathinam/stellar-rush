#pragma strict
 
public class MusicSingleton extends MonoBehaviour
{
    public static var instance : MusicSingleton;
 
    public var musicMainMenu : AudioClip;
    
    var isPlaying : int;
 
    function Awake() 
    {
        if ( instance != null && instance != this ) 
        {
            Destroy( this.gameObject );
            return;
        } 
        else 
        {
            instance = this;
        }
 
        DontDestroyOnLoad( this.gameObject );
        if(PlayerPrefs.GetInt("playMusic") != 0)
    	{
    		isPlaying = 0;
    		AudioListener.volume = 0.0;
    	}
    	else if (PlayerPrefs.GetInt("playMusic") == 0)
    	{
    		isPlaying = 1;
    		AudioListener.volume = 1.0;
    	}
    }
    function Start()
    {
    	
    }
 
    function OnLevelWasLoaded( level : int )
    {
        
        if(PlayerPrefs.GetInt("playMusic") != 0)
    	{
    		AudioListener.volume = 0.0;
    		isPlaying = 0;
   		}
   		
        if ( level == 5 )
        {
            audio.Stop();
        }
    	
    }
 
    public static function GetInstance() : MusicSingleton 
    {
        return instance;
    }
 
    function Update() 
    {
    	if(PlayerPrefs.GetInt("playMusic") != 0 && isPlaying != 0)
    	{
    		AudioListener.volume = 0.0;
    		isPlaying = 0;
   		}
   		if(PlayerPrefs.GetInt("playMusic") == 0 && isPlaying != 1)
    	{
    		AudioListener.volume = 1.0;
    		isPlaying = 1;
   		}
    }
 
}