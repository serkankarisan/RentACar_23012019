﻿using DAL.RentACar.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.RentACar.Repositories
{
    public class Giris : IGiris
    {
        
        public bool KullaniciKontrol(string KullaniciAdi, string Sifre)
        {
            bool Sonuc = false;
            
            Kullanici kullanici= Genel.ent.Kullanicilar.Where(k => k.UserName == KullaniciAdi && k.Password==Sifre).FirstOrDefault();

            string Sifrekontrol="";
            string Adkontrol="";
            if (kullanici!=null)
            {
                Sifrekontrol = kullanici.Password;
                Adkontrol = kullanici.UserName;
            }
            if (String.Compare(Sifre, Sifrekontrol, false)==0)
            {
                if (String.Compare(KullaniciAdi, Adkontrol, false) == 0)
                {
                    if (kullanici != null)
                    {
                        Genel.UserName = kullanici.Personel.Adi + "  " + kullanici.Personel.Soyadi;
                        Genel.Yetki = kullanici.Yetki.RoleName;
                        Genel.PersonelID = kullanici.PersonelId;
                        Sonuc = true;
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adınızı Kontroledin!!!", "Kullanıcı Adı Hatalı!!!");
                }
            }
            else
            {
                MessageBox.Show("Şifrenizi Kontroledin!!!", "Şifre Hatalı!!!");
            }
            return Sonuc;
        }

        public bool SifreDegistir()
        {
            throw new NotImplementedException();
        }

        //public bool KullaniciYetkiKontrol(Kullanici k)
        //{
        //    bool Sonuc = false;

        //    Kullanici kullanici = Genel.ent.Kullanicilar.Where(kul => kul.UserName == KullaniciAdi && k.Password == Sifre).FirstOrDefault();



        //    return Sonuc;
        //}
    }
}
