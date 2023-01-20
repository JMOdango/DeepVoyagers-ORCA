using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement; 


public class PlayFabManager : MonoBehaviour
{
    //SignIn/SignUp
    public static PlayFabManager PFM;
    VirtualCurrency virtualCurrency;
    InventoryManager inventory;
    [SerializeField] GameObject signUpTab, logInTab, startPanel, HUD;
    [SerializeField] TextMeshProUGUI username, userEmail, userPassword, userConfirmPass, userEmailLogin, userPasswordLogin, errorSignUp, errorLogin;
    string encryptedPassword;
    public int loading = 1;

    void OnEnable() {
        if(PlayFabManager.PFM == null)
        {
            PlayFabManager.PFM = this;
        }
        else
        {
            if(PlayFabManager.PFM != this){
                Destroy(this.gameObject);
            }
        }
    }

    public void Awake(){

    }

    public void Start(){
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "D546A";
        }
    }


    public void SwitchToSignUpTab(){
        signUpTab.SetActive(true);
        logInTab.SetActive(false);
        errorSignUp.text = "";
        errorLogin.text = "";
    }

    public void SwitchToLoginTab(){
        signUpTab.SetActive(false);
        logInTab.SetActive(true);
        errorSignUp.text = "";
        errorLogin.text = "";
    }

    string Encrypt(string pass){
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach(byte b in bs){
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

    public void SignUp(){
        if(userPassword.text.Length < 6){
            errorSignUp.text = "Password must have 6 or more characters";
            return;
        }
        if(userPassword.text != userConfirmPass.text){
            errorSignUp.text = "Password does not match";
            return;
        }
        var registerRequest = new RegisterPlayFabUserRequest{
            Email = userEmail.text, 
            Password = Encrypt(userPassword.text),
            Username = username.text.Remove(username.text.Length-1),
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterFailure);
    }

    public void RegisterSuccess(RegisterPlayFabUserResult result){
        errorSignUp.text = "";
        errorLogin.text = "";
        StartGame();
    }

    public void RegisterFailure(PlayFabError error){
        errorSignUp.text = error.ErrorMessage;
    }

    public void LogIn(){
        var request = new LoginWithEmailAddressRequest{
            Email = userEmailLogin.text, 
            Password = Encrypt(userPasswordLogin.text),
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginFailure);
    }

    public void LoginSuccess(LoginResult result){
        errorSignUp.text = "";
        errorLogin.text = "";
        StartGame();
        // InventoryManager.inventory.GetInventory();
    }

    public void LoginFailure(PlayFabError error){
        errorLogin.text = "Account or password error";
    }

    void StartGame(){
        SceneManager.LoadScene(loading);
    }

    public void ResetPassword(){
        var request = new SendAccountRecoveryEmailRequest{
            Email = userEmailLogin.text,
            TitleId = "D546A"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, PasswordResetSuccess, PasswordResetFailure);
    }

    void PasswordResetSuccess(SendAccountRecoveryEmailResult result){
        errorLogin.text = "Password reset mail sent";
    }

    void PasswordResetFailure(PlayFabError error){
        errorLogin.text = "There is an error with your request";
    }

    public void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }

    //PlayerStats

    public int playerLevel;

    public void SetStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics( new UpdatePlayerStatisticsRequest {
            // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate { StatisticName = "PlayerLevel", Value = playerLevel },
            }
        },
        result => { Debug.Log("User statistics updated"); },
        error => { Debug.LogError(error.GenerateErrorReport()); });
    }

    void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetStats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics){
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            switch(eachStat.StatisticName)
            {
                case "PlayerLevel":
                    playerLevel = eachStat.Value;
                    break;
            }
        }
    }
}
