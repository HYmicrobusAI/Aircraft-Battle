using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManagerSetting : MonoBehaviour {

    public Image AboutAuthorImage;
    public Image JianLi;

    public Image IntroductionImage;
    public Image NormalSettingImge;
    public Image SuperSettingImge;

    public Image PassWordSuperSettingImage;
    public InputField passwordField;
    public Text displayInfo;

    public Image changePWImage;
    public InputField changePassWord;
    public Image changeUIImage;
    public Text disText;
    public InputField changeUIInputField;

    private bool IsCorrect;
    public bool isChanged = false;

    private string SuperSettingPassword = "houchaoqun2242";

    //开挂数据
    public static float BullutSpeed = 5f;
    public static int BoomNumber = 0;
    public static float AwardTime = 0;
    public static bool unbeatable = false;
    //开挂确定控件
    public Button supperSettingOK;
    public InputField SupperBulletSpeed;
    public InputField SupperBoomNumber;
    public InputField SupperAwardTime;
    public Toggle SupperUnbeatable;
    public Text disInfo;

	// Use this for initialization
	void Start () {
        AboutAuthorImage.gameObject.SetActive(false);
        JianLi.gameObject.SetActive(false);
        IntroductionImage.gameObject.SetActive(false);
        NormalSettingImge.gameObject.SetActive(false);
        SuperSettingImge.gameObject.SetActive(false);
        PassWordSuperSettingImage.gameObject.SetActive(false);
        displayInfo.gameObject.SetActive(false);

        //超级密码更改界面
        changePWImage.gameObject.SetActive(false);
        changeUIImage.gameObject.SetActive(false);

        BullutSpeed = 5f;
        BoomNumber = 0;
        AwardTime = 0f;
        unbeatable = false;
	}
	
    public void enterIntroduction()
    {
        Application.LoadLevel("introductionGame");
    }

    public void enterAboutAuthor()
    {
        JianLi.gameObject.SetActive(false);
        IntroductionImage.gameObject.SetActive(false);
        NormalSettingImge.gameObject.SetActive(false);
        SuperSettingImge.gameObject.SetActive(false);
        PassWordSuperSettingImage.gameObject.SetActive(false);
        displayInfo.gameObject.SetActive(false);

        changePWImage.gameObject.SetActive(false);
        changeUIImage.gameObject.SetActive(false);

        AboutAuthorImage.gameObject.SetActive(true);
    }

    public void showJianLiButton()
    {
        AboutAuthorImage.gameObject.SetActive(false);
        JianLi.gameObject.SetActive(true);
    }

    public void NotShowJianLiButton()
    {
        JianLi.gameObject.SetActive(false);
        AboutAuthorImage.gameObject.SetActive(true);
    }

    public void enterNormalSetting()
    {
        AboutAuthorImage.gameObject.SetActive(false);
        JianLi.gameObject.SetActive(false);
        IntroductionImage.gameObject.SetActive(false);
        SuperSettingImge.gameObject.SetActive(false);
        PassWordSuperSettingImage.gameObject.SetActive(false);
        displayInfo.gameObject.SetActive(false);

        changePWImage.gameObject.SetActive(false);
        changeUIImage.gameObject.SetActive(false);

        NormalSettingImge.gameObject.SetActive(true);
    }

    public void enterPassWord()
    {
        AboutAuthorImage.gameObject.SetActive(false);
        JianLi.gameObject.SetActive(false);
        IntroductionImage.gameObject.SetActive(false);
        NormalSettingImge.gameObject.SetActive(false);
        SuperSettingImge.gameObject.SetActive(false);
        displayInfo.gameObject.SetActive(false);

        changePWImage.gameObject.SetActive(false);
        changeUIImage.gameObject.SetActive(false);

        PassWordSuperSettingImage.gameObject.SetActive(true);
    }

    public void enterSuperSetting()
    {
        AboutAuthorImage.gameObject.SetActive(false);
        JianLi.gameObject.SetActive(false);
        IntroductionImage.gameObject.SetActive(false);
        NormalSettingImge.gameObject.SetActive(false);
        PassWordSuperSettingImage.gameObject.SetActive(false);
        displayInfo.gameObject.SetActive(false);

        changePWImage.gameObject.SetActive(false);
        changeUIImage.gameObject.SetActive(false);

        
        PassWordSuperSettingImage.gameObject.SetActive(true);

        string password = passwordField.text;
        if (PassWordCheck(password))
        {
            displayInfo.gameObject.SetActive(true);
            displayInfo.text = "Succeed!!";
            PassWordSuperSettingImage.gameObject.SetActive(false);
            SuperSettingImge.gameObject.SetActive(true);
        }
        else
        {
            displayInfo.gameObject.SetActive(true);
            displayInfo.text = "Failure!!";
        }

        passwordField.text = "";   //预防下次输入的密码的时候，保留了上次的密码
        
    }

    private bool PassWordCheck(string PassWord)
    {
        IsCorrect = false;
        if(PassWord!=null)
        {
            if (PassWord.Trim().Equals(SuperSettingPassword))
            {
                IsCorrect = true;
            }
        }

        return IsCorrect;
    }

    //设置更改超级用户密码
    public void KaKaXiButton()
    {
        AboutAuthorImage.gameObject.SetActive(false);
        JianLi.gameObject.SetActive(false);
        IntroductionImage.gameObject.SetActive(false);
        NormalSettingImge.gameObject.SetActive(false);
        SuperSettingImge.gameObject.SetActive(false);
        PassWordSuperSettingImage.gameObject.SetActive(false);
        displayInfo.gameObject.SetActive(false);

        changePWImage.gameObject.SetActive(true);
    }

    public void InputPWButtonOK()
    {
        string PW = changePassWord.text;
        if (IsCorrectOK(PW))
        {
            changeUIImage.gameObject.SetActive(true);
        }
        else
        {
            print("UnCorrect PassWord!!");
        }
    }

    private bool IsCorrectOK(string PassWord)
    {
        bool IsCoreect2 = false;
        if(PassWord!=null)
        {
            if(PassWord.Trim().Equals("2242"))
            {
                IsCoreect2 = true;
            }
        }

        return IsCoreect2;
    }

    public void changeButtonUI()
    {
        SuperSettingPassword = changeUIInputField.text;
        disText.text = "Change Succeed!";
    }

    public void changeButtonReturn()
    {
        changeUIImage.gameObject.SetActive(false);
        changePWImage.gameObject.SetActive(false);
    }


    public void ReturnHomeButton()
    {
        Application.LoadLevel("HomeGameUI");
    }

    //修改英雄参数
    public void SupperSettingOK()
    {
        int num;
        
        if (!isChanged)
        {
            SupperBulletSpeed.text = "5";   //初始化输入窗口，以防使用“Parse”的时候出现异常
            SupperBoomNumber.text = "0";
            SupperAwardTime.text = "0";
        }
       
        if(SupperBulletSpeed.text != "5" )
        {
            num = int.Parse(SupperBulletSpeed.text);   //将字符串转化为整型
            if(num>=0)
            {
                BullutSpeed = num;
            }
            disInfo.text = "Changed Succeed!!";
        }
    
        if (SupperBoomNumber.text != "0")
        {
            num = int.Parse(SupperBoomNumber.text);   //将字符串转化为整型
            if (num >= 0)
            {
                BoomNumber = num;
            }
            disInfo.text = "Changed Succeed!!";
        }
       
        if (SupperAwardTime.text != "0")
        {
            num = int.Parse(SupperAwardTime.text);   //将字符串转化为整型
            if (num >= 0)
            {
                AwardTime = num;
            }
            disInfo.text = "Changed Succeed!!";
        }

        if(SupperUnbeatable.isOn)
        {
            unbeatable = true;
            disInfo.text = "Changed Succeed!!";
        }

        isChanged = true;
    }

    public void SupperSettingReturn()
    {
        SuperSettingImge.gameObject.SetActive(false);
        disInfo.text = "";  //修改属性的提示信息txt
    }
}
