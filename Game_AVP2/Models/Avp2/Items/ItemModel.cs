
using Game_AVP2.Models.Avp2.Items;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Game_AVP2.Models
{
    public class ItemModel : BaseModel
    {
        public List<Misc> MiscList { get; set; }
        public List<Armour> ArmourList { get; set; }
        public List<Weapon> WeaponList { get; set; }

        public ItemModel()
        {
        }

        internal void RenderAllItems(ApplicationDbContext db)
        {
            MiscList = db.Misc.ToList();
            ArmourList = db.Armours.ToList();
            WeaponList = db.Weapons.ToList();

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void StoreImage(object image)
        {
            //if (image != null)

            //{

            //    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);



            //    //Save files to disk

            //    FileUpload1.SaveAs(Server.MapPath("images/" + FileName));



            //    //Add Entry to DataBase

            //    String strConnString = System.Configuration.ConfigurationManager

            //        .ConnectionStrings["conString"].ConnectionString;

            //    SqlConnection con = new SqlConnection(strConnString);

            //    string strQuery = "insert into tblFiles (FileName, FilePath)" +

            //        " values(@FileName, @FilePath)";

            //    SqlCommand cmd = new SqlCommand(strQuery);

            //    cmd.Parameters.AddWithValue("@FileName", FileName);

            //    cmd.Parameters.AddWithValue("@FilePath", "images/" + FileName);

            //    cmd.CommandType = CommandType.Text;

            //    cmd.Connection = con;

            //    try

            //    {

            //        con.Open();

            //        cmd.ExecuteNonQuery();

            //    }

            //    catch (Exception ex)

            //    {

            //        Response.Write(ex.Message);

            //    }

            //    finally

            //    {

            //        con.Close();

            //        con.Dispose();

            //    }

            //}
        }

        //protected static void SetValue(object original, string theProperty, object theValue)
        //{
        //    try
        //    {
        //        PropertyInfo propertyInfo = original.GetType().GetProperty(theProperty);
        //        propertyInfo.SetValue(original, theValue, null);
        //        propertyInfo.GetType().GetProperties();

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //private static bool CheckPropertyModified(object original, object updated, bool nullCheck)
        //{
        //    bool modified = false;
        //    if (original != updated && nullCheck)
        //    {
        //        modified = true;

        //    }
        //    else
        //    {
        //        modified = false;
        //    }
        //    return modified;
        //}


        //modified = ItemModel.CheckPropertyModified(originalWeapon.Name, updatedWeapon.Name, (updatedWeapon.Name != null) ? true : false);
        //entry.Property(e => e.Name).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Name", updatedWeapon.Name);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.WeaponType, updatedWeapon.WeaponType, (updatedWeapon.WeaponType != null) ? true : false);
        //entry.Property(e => e.WeaponType).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "WeaponType", updatedWeapon.WeaponType);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Name, updatedWeapon.Name, (updatedWeapon.Name != null) ? true : false);
        //entry.Property(e => e.Name).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Description", updatedWeapon.Description);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Damage, updatedWeapon.Damage, (updatedWeapon.Damage != -1) ? true : false);
        //entry.Property(e => e.Damage).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Damage", updatedWeapon.Damage);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.ExtraDamage, updatedWeapon.ExtraDamage, (updatedWeapon.ExtraDamage != -1) ? true : false);
        //entry.Property(e => e.ExtraDamage).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "ExtraDamage", updatedWeapon.ExtraDamage);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Rarity, updatedWeapon.Rarity, (updatedWeapon.Rarity != -1) ? true : false);
        //entry.Property(e => e.Rarity).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Rarity", updatedWeapon.Rarity);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Value, updatedWeapon.Value, (updatedWeapon.Value != -1) ? true : false);
        //entry.Property(e => e.Value).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Value", updatedWeapon.Value);
        //}
    }
}