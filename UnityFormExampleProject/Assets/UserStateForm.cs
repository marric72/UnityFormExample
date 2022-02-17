using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The User class contains all information about the user
//public just for convenience.
public class User
{
    public string userName;
    public string city;
    public string state;

    public User(string u, string c, string s)
    {
        userName = u;
        city = c;
        state = s;
    }
}

//a class to help persist user data through PlayerPrefs
public static class UserData
{
    //keys used to set and get PlayPrefs
    public const string USER = "user";
    public const string CITY = "city";
    public const string STATE = "state";

    public static void saveUserData(User user)
    {
        PlayerPrefs.SetString(UserData.USER, user.userName);
        PlayerPrefs.SetString(UserData.CITY, user.city);
        PlayerPrefs.SetString(UserData.STATE, user.state);
    }
    public static User retrieveUserData()
    {
        if (PlayerPrefs.GetString(UserData.USER) == null)
        {
            return null;  //no user data saved
        }
        else
        {
            User u = new User(PlayerPrefs.GetString(UserData.USER),
              PlayerPrefs.GetString(UserData.CITY),
              PlayerPrefs.GetString(UserData.STATE));
            return u;
        }
    }
}

public class UserStateForm : MonoBehaviour
{
    //public int test;
    [SerializeField] InputField userName;
    [SerializeField] InputField city;
    [SerializeField] InputField state;

    // Start is called before the first frame update
    void Start()
    {
        //check to see if the PlayerPref set,
        //if so, pre-populate fields
        User u = UserData.retrieveUserData();
        if (u != null)
        {
            userName.text = u.userName;
            city.text = u.city;
            state.text = u.state;
        }
    }

    // Update is called once per frame
    public void CommitChanges()
    {
        print("button pressed");
        print("save userName:" + userName.text);
        print("save city:" + city.text);
        print("save state:" + state.text);
        User u = new User(userName.text, city.text, state.text);
        UserData.saveUserData(u);
    }
}
