using System.Windows.Forms;

public interface IDeviceControllerForm
{
    bool Focused { get; }

    FormWindowState WindowState { get; set; }

    void BringToFront();

    void SynchronizeFormControls();

    void Close();

    void Dispose();
}