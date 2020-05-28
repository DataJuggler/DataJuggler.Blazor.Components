

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DataJuggler.UltimateHelper.Core;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Enumerations;
using DataJuggler.RandomShuffler.Core;
using BlazorChat.Enumerations;
using ObjectLibrary.BusinessObjects;
using DataGateway;
using BlazorChat.Components;
using DataJuggler.Core.Cryptography;
using DataGateway.Services;

#endregion

namespace BlazorChat.Pages
{

    #region class Index : IProgressSubscriber, ISpriteSubscriber
    /// <summary>
    /// This class is the code behind for the Index page.
    /// </summary>
    public partial class Index : IProgressSubscriber, ISpriteSubscriber, IBlazorComponentParent
    {
        
        #region Private Variables
        private ProgressBar progressBar;
        private bool showBackground;
        private ThemeEnum progressTheme;
        private double backgroundScale;
        private bool showProgress;
        private List<IBlazorComponent> children;
        private ScreenTypeEnum screenType;
        private User loggedInUser;
        private string message;
        private Join joinComponent;
        private Login loginComponent;
        private Chat chatComponent;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an Index page.
        /// This constructor runs at Startup to perform initializations.
        /// </summary>
        public Index()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods
          
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
                // Default values
                BackgroundScale = 1;
                ShowBackground = true;
                ProgressTheme = ThemeEnum.Dark;
                Message = "Welcome To Blazor Chat.";               
            }
            #endregion

            #region LoginButton_Click()
            /// <summary>
            /// This method Login Button _ Click
            /// </summary>
            public void LoginButton_Click()
            {
                // Setup the Screen to Login
                ScreenType = ScreenTypeEnum.Login;
            }
            #endregion

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                // if there is not a logged in user
                if (!HasLoggedInUser)
                {
                    // locals
                    string emailAddress = "";
                    string storedPasswordHash = "";
                        
                    try
                    {
                        // get the values from local storage if present
                        bool rememberLogin = await ProtectedLocalStore.GetAsync<bool>("RememberLogin");

                        // if rememberLogin is true
                        if (rememberLogin)
                        {
                            emailAddress = await ProtectedLocalStore.GetAsync<string>("EmailAddress");
                            storedPasswordHash = await ProtectedLocalStore.GetAsync<string>("PasswordHash");

                            // If the emailAddress string exists
                            if (TextHelper.Exists(emailAddress))
                            {
                                // Attempt to find this user
                                User user = await UserService.FindUserByEmailAddress(emailAddress);

                                // If the user object exists
                                if (NullHelper.Exists(user))
                                {
                                    // get the key
                                    string key = EnvironmentVariableHelper.GetEnvironmentVariableValue("FiveByFiveGame");

                                    // if the key was found
                                    if (TextHelper.Exists(key))
                                    {
                                        // can this artist be verified
                                        bool isVerified = CryptographyHelper.VerifyHash(storedPasswordHash, key, user.PasswordHash, true);

                                        // if the value for isVerified is true
                                        if (isVerified)
                                        {
                                            // Set the LoggedInuser
                                            LoggedInUser = user;                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("OnAfterRenderAsync", "Login.cs", error);
                    }
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);

                // if the value for HasLoggedInUser is true
                if ((HasLoggedInUser) && (firstRender))
                {
                    // Refresh the UI
                    Refresh();
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
            
            #region Refresh(string message)
            /// <summary>
            /// This method is called by the ProgressBar when as it refreshes.
            /// </summary>
            public void Refresh(string message)
            {
                // if the ProgressBar exists and has reached the max of 100
                if ((HasProgressBar) && (ProgressBar.Percent >= 100))
                {
                    // Stop the ProgressBar
                    ProgressBar.Stop();

                    // Stop showing the ProgressBar
                    ShowProgress = false;                    
                }
            }
            #endregion

            #region Refresh()
            /// <summary>
            /// This method is called by a Sprite when as it refreshes.
            /// </summary>
            public void Refresh()
            {
                // Update the UI
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion

            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // if this is the Join object
                if (component is Join)
                {
                    // Store the JoinComponent
                    JoinComponent = component as Join;
                }
                // if the Login
                else if (component is Login)
                {
                    // Store the LoginComponent
                    LoginComponent = component as Login;
                }
                else if (component is Chat)
                {
                    // Store the Chat component
                    ChatComponent = component as Chat;
                }

                // if the value for HasChildren is true
                if (HasChildren)
                {
                    // add this item
                    this.Children.Add(component);
                }
            }
            #endregion
            
            #region Register(ProgressBar progressBar)
            /// <summary>
            /// This method Registers the ProgressBar with this app.
            /// </summary>
            public void Register(ProgressBar progressBar)
            {
                // store the ProgressBar
                this.ProgressBar = progressBar;  
            }
            #endregion

            #region Register(Sprite sprite)
            /// <summary>
            /// This method Registers the ProgressBar with this app.
            /// </summary>
            public void Register(Sprite sprite)
            {
                
            }
            #endregion

            #region RemovedLocalStoreItems()
            /// <summary>
            /// This method Removed Local Store Items
            /// </summary>
            public async Task<bool> RemovedLocalStoreItems()
            {
                // initial value
                bool removed = false;

                try
                {
                    // if the ProtectedLocalStore exists
                    if (ProtectedLocalStore != null)
                    {
                        // delete doesn't seem to work, so I am setting to false
                        await ProtectedLocalStore.SetAsync("RememberLogin", false);

                        // Remove all items
                        await ProtectedLocalStore.DeleteAsync("RememberPassword");
                        await ProtectedLocalStore.DeleteAsync("EmailAddress");
                        await ProtectedLocalStore.DeleteAsync("PasswordHash");
                    }

                    // set to true
                    removed = true;
                }
                catch (Exception error)
                {   
                    // for debugging only
                    DebugHelper.WriteDebugError("RemoveLocalStoreItems", "Login.cs", error);
                }

                // return value
                return removed;
            }
            #endregion

            #region SetupScreen(ScreenTypeEnum screenType)
            /// <summary>
            /// This method sets which type of screen is visible, login, join or main.
            /// </summary>
            public void SetupScreen(ScreenTypeEnum screenType)
            {
                // Set the new ScreenType
                ScreenType = screenType;

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region ShowMessage(string text)
            /// <summary>
            /// This method Show Message
            /// </summary>
            public void ShowMessage(string text)
            {
                // set the message
                Message = text;

                // Set the StateHasChanged
                StateHasChanged();
            }
            #endregion
            
            #region SignOutButton_Click()
            /// <summary>
            /// This method Sign Out Button _ Click
            /// </summary>
            public async void SignOutButton_Click()
            {
                // Log Out The User
                LoggedInUser = null;

                // Remove the items in Local Storage
                await RemovedLocalStoreItems();

                // update the UI
                Refresh();
            }
            #endregion

            #region SignUpButton_Click()
            /// <summary>
            /// This method Sign Up Button _ Click
            /// </summary>
            public void SignUpButton_Click()
            {
                // Setup the Screen
                ScreenType = ScreenTypeEnum.Join;
            }
            #endregion

            #region StoreLocalStoreItems(string emailAddress, string passwordHash)
            /// <summary>
            /// This method Store Local Store Items
            /// </summary>
            public async Task<bool> StoreLocalStoreItems(string emailAddress, string passwordHash)
            {
                // initial value
                bool saved = false;

                try
                {
                    // try saving
                    await ProtectedLocalStore.SetAsync("RememberLogin", true);
                    await ProtectedLocalStore.SetAsync("EmailAddress", emailAddress);
                    await ProtectedLocalStore.SetAsync("PasswordHash", passwordHash);

                    // presumption
                    saved = true;
                }
                catch (Exception error)
                {
                    // for debugging only for now
                    DebugHelper.WriteDebugError("StoreLocalStoreItems", "Index.razor.cs", error);
                }

                // return value
                return saved;
            }
            #endregion
          
        #endregion
            
        #region Properties
            
            #region BackgroundScale
            /// <summary>
            /// This property gets or sets the value for 'BackgroundScale'.
            /// </summary>
            public double BackgroundScale
            {
                get { return backgroundScale; }
                set { backgroundScale = value; }
            }
            #endregion
            
            #region ChatComponent
            /// <summary>
            /// This property gets or sets the value for 'ChatComponent'.
            /// </summary>
            public Chat ChatComponent
            {
                get { return chatComponent; }
                set { chatComponent = value; }
            }
            #endregion
            
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

            #region HasChatComponent
            /// <summary>
            /// This property returns true if this object has a 'ChatComponent'.
            /// </summary>
            public bool HasChatComponent
            {
                get
                {
                    // initial value
                    bool hasChatComponent = (this.ChatComponent != null);
                    
                    // return value
                    return hasChatComponent;
                }
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
            
            #region HasJoinComponent
            /// <summary>
            /// This property returns true if this object has a 'JoinComponent'.
            /// </summary>
            public bool HasJoinComponent
            {
                get
                {
                    // initial value
                    bool hasJoinComponent = (this.JoinComponent != null);
                    
                    // return value
                    return hasJoinComponent;
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
            
            #region HasLoginComponent
            /// <summary>
            /// This property returns true if this object has a 'LoginComponent'.
            /// </summary>
            public bool HasLoginComponent
            {
                get
                {
                    // initial value
                    bool hasLoginComponent = (this.LoginComponent != null);
                    
                    // return value
                    return hasLoginComponent;
                }
            }
            #endregion
            
            #region HasProgressBar
            /// <summary>
            /// This property returns true if this object has a 'ProgressBar'.
            /// </summary>
            public bool HasProgressBar
            {
                get
                {
                    // initial value
                    bool hasProgressBar = (this.ProgressBar != null);
                    
                    // return value
                    return hasProgressBar;
                }
            }
            #endregion
            
            #region JoinComponent
            /// <summary>
            /// This property gets or sets the value for 'JoinComponent'.
            /// </summary>
            public Join JoinComponent
            {
                get { return joinComponent; }
                set { joinComponent = value; }
            }
            #endregion
            
            #region LoggedInUser
            /// <summary>
            /// This property gets or sets the value for 'LoggedInUser'.
            /// </summary>
            public User LoggedInUser
            {
                get { return loggedInUser; }
                set 
                { 
                    // set the value
                    loggedInUser = value;

                    // if the ChatComponent exists
                    if ((HasChatComponent) && (HasLoggedInUser))
                    {
                        // Create a message
                        Message message = new Message();

                        // Set the Text
                        message.Text = "Logged In User Is Set";

                        // Send the message to the Chat component
                        ChatComponent.ReceiveData(message);
                    }
                }
            }
            #endregion
            
            #region LoginComponent
            /// <summary>
            /// This property gets or sets the value for 'LoginComponent'.
            /// </summary>
            public Login LoginComponent
            {
                get { return loginComponent; }
                set { loginComponent = value; }
            }
            #endregion
            
            #region Message
            /// <summary>
            /// This property gets or sets the value for 'Message'.
            /// </summary>
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
            #endregion
            
            #region ProgressBar
            /// <summary>
            /// This property gets or sets the value for 'ProgressBar'.
            /// </summary>
            public ProgressBar ProgressBar
            {
                get { return progressBar; }
                set { progressBar = value; }
            }
            #endregion
            
            #region ProgressTheme
            /// <summary>
            /// This property gets or sets the value for 'ProgressTheme'.
            /// </summary>
            public ThemeEnum ProgressTheme
            {
                get { return progressTheme; }
                set { progressTheme = value; }
            }
            #endregion
            
            #region ScreenType
            /// <summary>
            /// This property gets or sets the value for 'ScreenType'.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                get { return screenType; }
                set { screenType = value; }
            }
            #endregion
            
            #region ShowBackground
            /// <summary>
            /// This property gets or sets the value for 'ShowBackground'.
            /// </summary>
            public bool ShowBackground
            {
                get { return showBackground; }
                set { showBackground = value; }
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

        #endregion

    }
    #endregion

}
