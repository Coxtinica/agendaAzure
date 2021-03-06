﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace agendaAzure
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MobileServiceClient client;

            IMobileServiceTable<agendaAzure> tabla;

            client = new MobileServiceClient(Conexion.ApplicationURL);

            tabla = client.GetTable<agendaAzure>();

            Label titulo = new Label()
            {
                Text = "Agenda",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 35,
                TextColor = Color.Aqua
        };


            Entry nombre1 = new Entry
            {
                Placeholder = "Nombre",
                FontAttributes = FontAttributes.None,
                BackgroundColor = Color.Silver,

            };


            Entry apellido1 = new Entry()
            {
                Placeholder = "Apellido",
                FontAttributes = FontAttributes.None,
                BackgroundColor = Color.Silver,
            };

            Entry telefono1 = new Entry()
            {
                Placeholder = "Numero",
                FontAttributes = FontAttributes.None,
                BackgroundColor = Color.Silver,
            };

            Button enviar = new Button()
            {
                Text = "Guardar Contacto",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions=LayoutOptions.CenterAndExpand
                
            };
            Button leer = new Button()
            {
                Text = "Mostrar Contactos",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };


            ListView lista = new ListView();
            ListView lista2 = new ListView();


            leer.Clicked += async (sender, args) =>
            {
                IEnumerable<agendaAzure> items = await tabla
                .ToEnumerableAsync();


                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;


                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    i++;
                }


                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };


            enviar.Clicked += async (sender, args) =>
            {
                var datos = new agendaAzure { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };
                await tabla.InsertAsync(datos);
                IEnumerable<agendaAzure> items = await tabla
                .ToEnumerableAsync();

                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;


                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };


            //eliminar
            // Button actualizar = new Button()
            Button eliminar = new Button()
            {
                Text = "Eliminar Contacto",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };


            eliminar.Clicked += async (sender, args) =>
            {
                IEnumerable<agendaAzure> items = await tabla
                .ToEnumerableAsync();

                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    //...
                    if (x.Cellphone == telefono1.Text)
                    {
                        if (x.Name != nombre1.Text)
                        {
                            x.Name = nombre1.Text;
                        }
                        if (x.Lastname != apellido1.Text)
                        {
                            x.Lastname = apellido1.Text;
                        }
                        await tabla.DeleteAsync(x);
                    }
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };


            //Ac
             Button actualizar = new Button()            
            {
                Text = "Actualizar Contacto",
                 FontAttributes = FontAttributes.Bold,
                 HorizontalOptions = LayoutOptions.CenterAndExpand
             };

            actualizar.Clicked += async (sender, args) =>
            {
                IEnumerable<agendaAzure> items = await tabla
                .ToEnumerableAsync();

                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;

                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;


                    if (x.Cellphone == telefono1.Text)
                    {
                        if (x.Name != nombre1.Text)
                        {
                            x.Name = nombre1.Text;
                        }
                        if (x.Lastname != apellido1.Text)
                        {
                            x.Lastname = apellido1.Text;
                        }
                        await tabla.UpdateAsync(x);
                    }
                    i++;
                }

                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };



            //mostrando
            var layout = new StackLayout();
            layout.Children.Add(titulo);
            layout.Children.Add(nombre1);
            layout.Children.Add(apellido1);
            layout.Children.Add(telefono1);
            layout.Children.Add(enviar);
            layout.Children.Add(leer);
            layout.Children.Add(actualizar);
            layout.Children.Add(eliminar);
            layout.Children.Add(lista);
            layout.Children.Add(lista2);


            MainPage = new ContentPage
            {
                Content = layout
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}