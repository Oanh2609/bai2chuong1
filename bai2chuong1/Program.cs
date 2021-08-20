using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2chuong1
{
   
             class PhanSo
        {
            protected int Mau, Tu;
            //public PhanSo(int mau, int tu)
            //{
            //    this.Tu = tu;
            //    this.Mau = mau;
            //}
            public void Nhap()
            {
                int a = 0, b = 0;
                Console.Write("\nNhap vao phan so [a/b]:  ");
                NhapThem(ref a, ref b);
                this.Tu = a;
                this.Mau = b;
            }

            public void NhapThem(ref int a, ref int b)
            {
                string so = Console.ReadLine();
                string[] splitStr = so.Split('/');
                a = int.Parse(splitStr[0]);
                b = int.Parse(splitStr[1]);
            }



            public void Gan(int tu, int mau)
            {
                this.Tu = tu;
                this.Mau = mau;
            }

            public void Xuat()
            {
                Console.WriteLine("Phan so la: {0}/{1}", Tu, Mau);

            }

            public void Cong(int a, int b)
            {
                this.Tu = a * Mau + b * Tu;
                this.Mau = b * Mau;
            }
            public PhanSo Tru(PhanSo S1)
            {
                if (this.Tu != 0)
                {
                    PhanSo ps1 = new PhanSo();
                    ps1.Tu = Tu * S1.Mau - Mau * S1.Tu;
                    ps1.Mau = Mau * S1.Mau;
                    return ps1;
                }
                else
                {
                    PhanSo ps = new PhanSo();
                    ps.Tu = -S1.Tu;
                    ps.Mau = S1.Mau;
                    return ps;
                }
            }

            private int UCLN(int a, int b)
            {

                if (a != 0)
                {
                    if (a > 0)
                    {
                        while (a != b)
                        {
                            if (a > b) a -= b;
                            else b -= a;
                        }
                        return a;
                    }
                    else
                    {
                        a = -a;
                        while (a != b)
                        {
                            if (a > b) a -= b;
                            else b -= a;
                        }
                        return a;
                    }
                }
                else return 0;

            }

            public void rutGon()
            {
                int a = UCLN(this.Tu, this.Mau);

                if (a != 0)
                {
                    if (a > 0)
                    {
                        this.Tu = this.Tu / a;
                        this.Mau = this.Mau / a;
                    }
                    else
                    {
                        this.Tu = this.Tu / (-a);
                        this.Mau = this.Mau / (a);
                    }
                }
                else
                {
                    Gan(0, 0);
                }
            }
        }
        class Phanso
        {
            static void Main(string[] args)
            {
                int a = 0, b = 0;
                PhanSo ps = new PhanSo();
            tag:
                ps.Nhap();
                ps.rutGon();
                ps.Xuat();


                Console.WriteLine("\nXin moi chon chuc nang: ");
                Console.WriteLine("Bam 1 de cong phan so[a/b]");
                Console.WriteLine("Bam 2 de tru phan so[a/b]");
                Console.WriteLine("Bam 3 Exit.");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Write("\nNhap vao phan so: ");
                        ps.NhapThem(ref a, ref b);
                        ps.Cong(a, b);
                        ps.rutGon();
                        ps.Xuat();
                        goto tag;
                       


                    case 2:
                        Console.Write("\nNhap vao phan so: ");
                        PhanSo ps1 = new PhanSo();
                        ps1.Nhap();
                        ps = ps.Tru(ps1);
                        ps.rutGon();
                        ps.Xuat();
                        goto tag;
                        

                    
                       
                }
            }
        }
    } 

