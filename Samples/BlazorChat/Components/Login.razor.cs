

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using DataJuggler.UltimateHelper.Core;
using DataJuggler.UltimateHelper.Core.Objects;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using ObjectLibrary.BusinessObjects;
using DataGateway.Services;
using ObjectLibrary.Enumerations;
using DataJuggler.Core.Cryptography;
using Microsoft.AspNetCore.Components;
using System.Threading;
using System.Threading.Tasks;
using BlazorChat.Enumerations;

#endregion

namespace BlazorChat.Components
{

    #region class Login
    /// <summary>
    /// This class is the code behind for the Index page.
    /// </summary>
    public partial class Login : IBlazorComponentParent, IBlazorComponent, ISpriteSubscriber, IDisposable
    {

        #region Private Variables
        private List<IBlazorComponent> children;
        private string emailAddress;
        private ValidationComponent emailAddressComponent;
        private ValidationComponent passwordComponent;
        private ValidationComponent userNameComponent;
        private ValidationComponent rememberLoginComponent;
        private string userName;
        private string validationMessage;
        private string password;
        private int userId;
        private bool rememberLogin;
        private string storedPasswordHash;
        private string name;
        private IBlazorComponentParent parent;
        private bool showProgress;        
        private bool loginInProcess;
        private int percent;
        private string percentString;
        private string progressStyle;
        private Sprite invisibleSprite;
        private int extraPercent;
        private User loggedInUser;
        #endregion

        #region Consructor
        /// <summary>
        /// Create a new index of an Join page
        /// </summary>
        public Login()
        {
           // Perform initializations for this object
           Init();
        }
        #endregion

        #region Methods

            #region Cancel()
            /// <summary>
            /// This method Cancel
            /// </summary>
            public void Cancel()
            {
                // if the value for HasParentIndexPage is true
                if (HasParentIndexPage)
                {
                    // Restore back to main screen
                    ParentIndexPage.SetupScreen(ScreenTypeEnum.Main);
                }
            }
            #endregion
            
            #region CheckValidEmail(string emailAddress)
            /// <summary>
            /// This method returns the Valid Email
            /// </summary>
            public bool CheckValidEmail(string emailAddress)
            {
                // initial value
                bool isValidEmail = false;

                try
                {
                    // If the emailAddress string exists
                    if (TextHelper.Exists(emailAddress))
                    {
                        // find the at Sign
                        int atSignIndex = emailAddress.IndexOf("@");

                        // if found
                        if (atSignIndex > 0)
                        {
                            // get the wordBefore
                            string wordBefore = emailAddress.Substring(0, atSignIndex -1);

                            // get the words after
                            string wordsAfter = emailAddress.Substring(atSignIndex + 1);

                            // get the delimiters
                            char[] delimiters = { '.' };

                            // get the words
                            List<Word> words = WordParser.GetWords(wordsAfter, delimiters);

                            // if there are 2 or more words, this should be valid
                            isValidEmail = ((TextHelper.Exists(wordBefore)) && (ListHelper.HasXOrMoreItems(words, 2)));
                        } 
                    }
                } 
                catch (Exception error)
                {
                    // not valid
                    isValidEmail = false;

                    // for debugging only
                    DebugHelper.WriteDebugError("CheckValidEmail", "Join.razor.cs", error);
                }
                
                // return value
                return isValidEmail;
            }
            #endregion
            
            #region Dispose()
            /// <summary>
            /// method Dispose
            /// </summary>
            public void Dispose()
            {
                if ((HasInvisibleSprite) && (NullHelper.Exists(InvisibleSprite.Timer)))
                {
                    // Stop the Timer
                    InvisibleSprite.Timer.Stop();

                    // Dispose of the timer
                    InvisibleSprite.Timer.Dispose();
                }

                // destroy
                InvisibleSprite = null;
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // initial value
                IBlazorComponent child = null;

                // if the value for HasChildren is true
                if (HasChildren)
                {
                    // Iterate the collection of IBlazorComponent objects
                    foreach (IBlazorComponent tempChild in Children)
                    {
                        // if this is the item being sought
                        if (TextHelper.IsEqual(tempChild.Name, name))
                        {
                            // set the return value
                            child = tempChild;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return child;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'IBlazorComponent' objects.
                Children = new List<IBlazorComponent>();
            }
            #endregion

            #region HandleRememberPassword()
            /// <summary>
            /// This method Handle Remember Password
            /// </summary>
            public async Task<bool> HandleRememberPassword()
            {
                // initial value
                bool saved = false;

                // if the value for HasParentIndexPage is true
                if (HasParentIndexPage)
                {
                    // if remember login details is true
                    if ((RememberLogin) && (HasLoggedInUser))
                    {
                        // Store the local store items
                        await ParentIndexPage.StoreLocalStoreItems(LoggedInUser.EmailAddress, LoggedInUser.PasswordHash);                        
                    }
                    else
                    {
                        // Remove any locally stored items
                        await ParentIndexPage.RemovedLocalStoreItems();
                    }
                }

                // return value
                return saved;
            }
            #endregion
            
            #region LoginButton_Click()
            /// <summary>
            /// This method Login Button _ Click
            /// </summary>
            public async void LoginButton_Click()
            {
                // if the value for HasParentIndexPage is true
                if (HasParentIndexPage)
                {
                    // Set to 0 percent
                    Percent = 0;

                    // Process the Login
                    bool started = await StartProcessLogin();

                    // Now start the Timer in the invisible sprite. 
                    // The Refresh method gets called every time the Interval of the Sprite elapses.
                    
                    // if the InvisiibleSprite exists
                    if ((HasInvisibleSprite) && (started))
                    {
                        // A login in process is true
                        LoginInProcess = true;

                        // Start the Timer
                        InvisibleSprite.Start();
                    }

                    // Show the ProgressBar
                    ShowProgress = true;                    
                }
            }
            #endregion

            #region ProcessNewUserSignUp(object userObject)
            /// <summary>
            /// This method Process New User Sign Up
            /// </summary>
            public async void ProcessVerifyPassword(object userObject)
            {
                try
                {
                    // cast the object as a signUpModel object
                    User user = userObject as User;

                    // If the user object exists
                    if (NullHelper.Exists(user))
                    {
                        // Get the KeyCode
                        string keyCode = EnvironmentVariableHelper.GetEnvironmentVariableValue("FiveByFiveGame");

                        // verify the user is logged in
                        bool verified = CryptographyHelper.VerifyHash(password, keyCode, user.PasswordHash);

                        // if not verified
                        if (!verified)
                        {
                            // Set the message
                            ValidationMessage = "The credentials entered were either not found or invalid.";

                            // hide the progress
                            ShowProgress = false;
                        }
                        else
                        {
                             // Set the LoggedInUser on this page
                            LoggedInUser = user;

                            // Set the LoggedInUser
                            ParentIndexPage.LoggedInUser = user;

                            // if the value for RememberLogin is true
                            if (RememberLogin)
                            {
                                // Save the login details in local protected storage
                                await HandleRememberPassword();
                            }

                            // Update the login information for this user
                            user.LastLoginDate = DateTime.Now;

                            // add to their total logins
                            user.TotalLogins++;

                            // Save the user
                            bool saved = await UserService.SaveUser(ref user);

                            // Set the Logged In User
                            ParentIndexPage.LoggedInUser = user;

                            // Return to the Main Screen, and now you can enter chat
                            ParentIndexPage.SetupScreen(ScreenTypeEnum.Main);
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only for now
                    DebugHelper.WriteDebugError("ProcessVerifyPassword", "Login.razor.cs", error);
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                // if the value for LoginInProcess is true
                if (LoginInProcess)
                {
                    // increment by 4
                    Percent += 4;

                    // go a little past 100 for effect
                    if (Percent >= 100)
                    {
                        // Increment
                        ExtraPercent++;
                    }

                    // if higher than 10
                    if (ExtraPercent >= 10)
                    {
                        // Stop the timer
                        InvisibleSprite.Stop();
                        ShowProgress = false;
                    }
                }

                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(Sprite sprite)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(Sprite sprite)
            {
                // Set the InvisibleSprite
                InvisibleSprite = sprite;
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // If the component object exists
                if (NullHelper.Exists(component))
                {
                    // if this is the UserName component
                    if (component.Name == "UserNameComponent")
                    {
                        // Set the component
                        UserNameComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "EmailAddressComponent")
                    {
                        // Set the component
                        EmailAddressComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "PasswordComponent")
                    {
                        // Set the component
                        PasswordComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "RememberLoginComponent")
                    {
                        // Set the component
                        RememberLoginComponent = component as ValidationComponent;
                    }
                    
                    // if the Children collection exists
                    if (HasChildren)
                    {
                        // Add this item
                        Children.Add(component);
                    }
                }
            }
        #endregion

            #region StartProcessLogin()
            /// <summary>
            /// This method returns the Process Login
            /// </summary>
            public async Task<bool> StartProcessLogin()
            {
                // initial value
                bool started = false;

                // Clear message
                ValidationMessage = "";

                // local
                User user = null;

                // if the value for HasUserNameComponent is true
                if (HasUserNameComponent)
                {
                    // Get the value
                    UserName = UserNameComponent.Text;
                }

                // if the value for HasEmailAddressComponent is true
                if (HasEmailAddressComponent)
                {
                    // Set the EmailAddress
                    EmailAddress = EmailAddressComponent.Text;
                }

                // if the value for HasPasswordComponent is true
                if (HasPasswordComponent)
                {
                    // Get the value
                    Password = PasswordComponent.Text;
                }

                // if the value for HasRememberLoginComponent is true
                if (HasRememberLoginComponent)
                {
                    // Get the value for Remember Login
                    RememberLogin = RememberLoginComponent.CheckBoxValue;
                }

                // If the UserName string exists
                if (TextHelper.Exists(UserName))
                {
                    // Attempt to find the user
                    user = await UserService.FindUserByUserName(UserName);
                }
                // If the EmailAddress string exists
                else if (TextHelper.Exists(EmailAddress))
                {
                    // Attempt to find the user
                    user = await UserService.FindUserByEmailAddress(EmailAddress);
                }
                else
                {
                    // Show a message
                    ValidationMessage = "You must enter a user name or an email address";
                }

                // if the user exists
                if (NullHelper.Exists(user))
                {
                    // Start Background Thread

                    // Create a Thread to Process the Signup
                    Thread thread = new Thread(ProcessVerifyPassword);

                    // Set the value for the property 'IsBackground' to true                        
                    thread.IsBackground = true;

                    // Startup the thread and pass in the SignUp model
                    thread.Start(user);

                    // set the return value to true
                    started = true;
                }
                
                // return value
                return started;
            }
            #endregion
            
        #endregion

        #region Properties

            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion
            
            #region EmailAddress
            /// <summary>
            /// This property gets or sets the value for 'EmailAddress'.
            /// </summary>
            public string EmailAddress
            {
                get { return emailAddress; }
                set { emailAddress = value; }
            }
            #endregion
            
            #region EmailAddressComponent
            /// <summary>
            /// This property gets or sets the value for 'EmailAddressComponent'.
            /// </summary>
            public ValidationComponent EmailAddressComponent
            {
                get { return emailAddressComponent; }
                set { emailAddressComponent = value; }
            }
            #endregion
            
            #region ExtraPercent
            /// <summary>
            /// This property gets or sets the value for 'ExtraPercent'.
            /// </summary>
            public int ExtraPercent
            {
                get { return extraPercent; }
                set { extraPercent = value; }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                    
                    // return value
                    return hasChildren;
                }
            }
            #endregion
            
            #region HasEmailAddressComponent
            /// <summary>
            /// This property returns true if this object has an 'EmailAddressComponent'.
            /// </summary>
            public bool HasEmailAddressComponent
            {
                get
                {
                    // initial value
                    bool hasEmailAddressComponent = (this.EmailAddressComponent != null);
                    
                    // return value
                    return hasEmailAddressComponent;
                }
            }
            #endregion
            
            #region HasInvisibleSprite
            /// <summary>
            /// This property returns true if this object has an 'InvisibleSprite'.
            /// </summary>
            public bool HasInvisibleSprite
            {
                get
                {
                    // initial value
                    bool hasInvisibleSprite = (this.InvisibleSprite != null);
                    
                    // return value
                    return hasInvisibleSprite;
                }
            }
            #endregion
            
            #region HasLoggedInUser
            /// <summary>
            /// This property returns true if this object has a 'LoggedInUser'.
            /// </summary>
            public bool HasLoggedInUser
            {
                get
                {
                    // initial value
                    bool hasLoggedInUser = (this.LoggedInUser != null);
                    
                    // return value
                    return hasLoggedInUser;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasParentIndexPage
            /// <summary>
            /// This property returns true if this object has a 'ParentIndexPage'.
            /// </summary>
            public bool HasParentIndexPage
            {
                get
                {
                    // initial value
                    bool hasParentIndexPage = (this.ParentIndexPage != null);
                    
                    // return value
                    return hasParentIndexPage;
                }
            }
            #endregion
            
            #region HasPasswordComponent
            /// <summary>
            /// This property returns true if this object has a 'PasswordComponent'.
            /// </summary>
            public bool HasPasswordComponent
            {
                get
                {
                    // initial value
                    bool hasPasswordComponent = (this.PasswordComponent != null);
                    
                    // return value
                    return hasPasswordComponent;
                }
            }
            #endregion
            
            #region HasRememberLoginComponent
            /// <summary>
            /// This property returns true if this object has a 'RememberLoginComponent'.
            /// </summary>
            public bool HasRememberLoginComponent
            {
                get
                {
                    // initial value
                    bool hasRememberLoginComponent = (this.RememberLoginComponent != null);
                    
                    // return value
                    return hasRememberLoginComponent;
                }
            }
            #endregion
            
            #region HasUserNameComponent
            /// <summary>
            /// This property returns true if this object has an 'UserNameComponent'.
            /// </summary>
            public bool HasUserNameComponent
            {
                get
                {
                    // initial value
                    bool hasUserNameComponent = (this.UserNameComponent != null);
                    
                    // return value
                    return hasUserNameComponent;
                }
            }
            #endregion

            #region InvisibleSprite
            /// <summary>
            /// This property gets or sets the value for 'InvisibleSprite'.
            /// </summary>
            public Sprite InvisibleSprite
            {
                get { return invisibleSprite; }
                set { invisibleSprite = value; }
            }
            #endregion
            
            #region LoggedInUser
            /// <summary>
            /// This property gets or sets the value for 'LoggedInUser'.
            /// </summary>
            public User LoggedInUser
            {
                get { return loggedInUser; }
                set { loggedInUser = value; }
            }
            #endregion
            
            #region LoginInProcess
            /// <summary>
            /// This property gets or sets the value for 'LoginInProcess'.
            /// </summary>
            public bool LoginInProcess
            {
                get { return loginInProcess; }
                set { loginInProcess = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set 
                { 
                    // set the value
                    parent = value;

                    // if the Parent exists
                    if (HasParent)
                    {
                        // Register with the parent
                        Parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region ParentIndexPage
            /// <summary>
            /// This read only property returns the value for 'ParentIndexPage'.
            /// </summary>
            public BlazorChat.Pages.Index ParentIndexPage
            {
                get
                {
                    // cast the parent as an Index page
                    return this.Parent as BlazorChat.Pages.Index;
                }
            }
            #endregion
            
            #region Percent
            /// <summary>
            /// This property gets or sets the value for 'Percent'.
            /// </summary>
            public int Percent
            {
                get { return percent; }
                set 
                {
                    // if less than zero
                    if (value < 0)
                    {
                        // set to 0
                        value = 0;
                    }

                    // if greater than 100
                    if (value > 100)
                    {
                        // set to 100
                        value = 100;
                    }

                    // set the value
                    percent = value;

                    // Now set ProgressStyle
                    ProgressStyle = "c100 p[Percent] dark small orange".Replace("[Percent]", percent.ToString());

                    // Set the percentString value
                    PercentString = percent.ToString() + "%";
                }
            }
            #endregion
            
            #region PercentString
            /// <summary>
            /// This property gets or sets the value for 'PercentString'.
            /// </summary>
            public string PercentString
            {
                get { return percentString; }
                set { percentString = value; }
            }
            #endregion
            
            #region ProgressStyle
            /// <summary>
            /// This property gets or sets the value for 'ProgressStyle'.
            /// </summary>
            public string ProgressStyle
            {
                get { return progressStyle; }
                set { progressStyle = value; }
            }
            #endregion

            #region RememberLogin
            /// <summary>
            /// This property gets or sets the value for 'RememberLogin'.
            /// </summary>
            public bool RememberLogin
            {
                get { return rememberLogin; }
                set { rememberLogin = value; }
            }
            #endregion
            
            #region Password
            /// <summary>
            /// This property gets or sets the value for 'Password'.
            /// </summary>
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            #endregion
            
            #region PasswordComponent
            /// <summary>
            /// This property gets or sets the value for 'PasswordComponent'.
            /// </summary>
            public ValidationComponent PasswordComponent
            {
                get { return passwordComponent; }
                set { passwordComponent = value; }
            }
            #endregion

            #region RememberLoginComponent
            /// <summary>
            /// This property gets or sets the value for 'RememberLoginComponent'.
            /// </summary>
            public ValidationComponent RememberLoginComponent
            {
                get { return rememberLoginComponent; }
                set { rememberLoginComponent = value; }
            }
            #endregion
            
            #region ShowProgress
            /// <summary>
            /// This property gets or sets the value for 'ShowProgress'.
            /// </summary>
            public bool ShowProgress
            {
                get { return showProgress; }
                set { showProgress = value; }
            }
            #endregion
            
            #region StoredPasswordHash
            /// <summary>
            /// This property gets or sets the value for 'StoredPasswordHash'.
            /// </summary>
            public string StoredPasswordHash
            {
                get { return storedPasswordHash; }
                set { storedPasswordHash = value; }
            }
            #endregion
            
            #region UserId
            /// <summary>
            /// This property gets or sets the value for 'UserId'.
            /// </summary>
            public int UserId
            {
                get { return userId; }
                set { userId = value; }
            }
            #endregion
            
            #region UserName
            /// <summary>
            /// This property gets or sets the value for 'UserName'.
            /// </summary>
            public string UserName
            {
                get { return userName; }
                set { userName = value; }
            }
            #endregion
            
            #region UserNameComponent
            /// <summary>
            /// This property gets or sets the value for 'UserNameComponent'.
            /// </summary>
            public ValidationComponent UserNameComponent
            {
                get { return userNameComponent; }
                set { userNameComponent = value; }
            }
            #endregion
            
            #region ValidationMessage
            /// <summary>
            /// This property gets or sets the value for 'ValidationMessage'.
            /// </summary>
            public string ValidationMessage
            {
                get { return validationMessage; }
                set { validationMessage = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
