namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
	public event EventHandler<string> OnError;
	public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public ContactControl()
	{
		InitializeComponent();
	}
	public string Name
	{
		get
		{
			return entryName.Text;
		}
		set
		{
			entryName.Text = value;	
		}
	}

    public string Address { get; internal set; }
    public string Email { get; internal set; }
    public string Phone { get; internal set; }

    private void btnSave_Clicked(object sender, EventArgs e)
	{
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required.");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
				OnError?.Invoke(sender, error.ToString());
            }
            return;

        }
		OnSave?.Invoke(sender, e);
    }
	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		OnCancel?.Invoke(sender, e);
	}
}
