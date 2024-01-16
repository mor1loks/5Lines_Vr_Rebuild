using System.Collections.Generic;
using System.Linq;
public class DietButtonNames
{
    private List<string> _plusButtons;
    private List<string> _minusButtons;
    public DietButtonNames()
    {
        _plusButtons = new List<string>();
        _minusButtons = new List<string>();
        FillPlusList();
        FillMinusList();
    }
    public bool HasPlusButton(string buttonName)
    {
        if(_plusButtons.FirstOrDefault(b=>b== buttonName)!=null)
            return true;
        return false;
    }
    public bool HasMinusButton(string buttonName)
    {
        if (_minusButtons.FirstOrDefault(b => b == buttonName) != null)
            return true;
        return false;
    }
    private void FillPlusList()
    {
        _plusButtons.Add("d_clutch_radio_c2");
        _plusButtons.Add("d_e_drive_radio_c2");
        _plusButtons.Add("d_rod_radio_c2");
        _plusButtons.Add("d_apron_radio_c2");
        _plusButtons.Add("d_hollow_left_radio_c2");
        _plusButtons.Add("d_hollow_right_radio_c2");
        _plusButtons.Add("d_board_front_radio_c2");
        _plusButtons.Add("d_board_back_radio_c2");
        _plusButtons.Add("d_stativ_front_radio_c2");
        _plusButtons.Add("d_stativ_back_radio_c2");
    }
    private void FillMinusList()
    {
        _minusButtons.Add("d_clutch_radio_c1");
        _minusButtons.Add("d_e_drive_radio_c1");
        _minusButtons.Add("d_rod_radio_c1");
        _minusButtons.Add("d_apron_radio_c1");
        _minusButtons.Add("d_hollow_left_radio_c1");
        _minusButtons.Add("d_hollow_right_radio_c1");
        _minusButtons.Add("d_board_front_radio_c1");
        _minusButtons.Add("d_board_back_radio_c1");
        _minusButtons.Add("d_stativ_front_radio_c1");
        _minusButtons.Add("d_stativ_back_radio_c1");
    }
}
