using rcorralesS5.Models;

namespace rcorralesS5.Vistas;

public partial class VistaPersona : ContentPage
{
	public VistaPersona()
	{
		InitializeComponent();
	}

    private void btninsertar_Clicked(object sender, EventArgs e)
    {
        lbstatus.Text = "";
        App.personaRepo.AddNewPersona(txtname.Text);
        lbstatus.Text = App.personaRepo.statusmessage;
        txtname.Text = "";

    }

    private void btnobtener_Clicked(object sender, EventArgs e)
    {
        lbstatus.Text = "";
        List<Persona> people = App.personaRepo.GetAllPersona();
        listapersona.ItemsSource = people;
        lbstatus.Text = App.personaRepo.statusmessage;
    }

    private void btneliminar_Clicked(object sender, EventArgs e)
    {
        lbstatus.Text = "";
        App.personaRepo.DeletePersona(txtname.Text);
        lbstatus.Text = App.personaRepo.statusmessage;
    }

    private void btnactualizar_Clicked(object sender, EventArgs e)
    {
        lbstatus.Text = "";
        List<Persona> people = App.personaRepo.GetAllPersona();
        listapersona.ItemsSource = people;
        lbstatus.Text = App.personaRepo.statusmessage;
    }
}