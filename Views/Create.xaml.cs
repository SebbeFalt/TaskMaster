using TaskMaster.ViewModels;

namespace TaskMaster.Views;

public partial class Create : ContentPage
{
	public Create(CreateViewModel createViewModel)
	{
		InitializeComponent();
		BindingContext = createViewModel;
	}
}