using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using ClassLibrary;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CompStore.Models.DAO
{

  

    public class DAOUser
    {

        public DAOUser()
        {
            XmlConfigurator.Configure();
        }


        private static readonly ILog log = LogManager.GetLogger(typeof(DAOUser));
        Entities entities = new Entities();


        public IEnumerable<User> GetAllUsers()
        {
           
            try
            {
                log.Debug("Запрос на получение данных прошел успешно ");
            }
            catch (SqlException ex)
            {
                log.Error("Ошибка в методе получения данных "+ex);
            }
            return entities.User.Select(n => n);
        }
       

        public User GetUser(int id)
        {
            return entities.User.Where(n => n.Id == id).First();
        }


        public bool AddUser(User st)
        {
            try
            {
                entities.User.Add(st);
                entities.SaveChanges();
                log.Debug("Запрос на добавление прошел успешно ");
            }
            catch (Exception ex)
            {
                log.Error("Ошибка в методе добавления: " + ex);
            }
            return true;
        }


                public bool UpdateSalary(User st)
        {

            try
            {
                var Entity = entities.User.FirstOrDefault(x => x.Id == st.Id);
                Entity.Login = st.Login;
                Entity.Password = st.Password;
                Entity.Surname = st.Surname;
                Entity.Name = st.Name;
                Entity.Post = st.Post;
                Entity.n_per_file = st.n_per_file;
                Entity.Id_shop = st.Id_shop;
                Entity.Salary = st.Salary;
                Entity.Id_role  = st.Id_role;

                entities.SaveChanges();
                log.Debug("Запрос на изменение прошел успешно ");
            }
            catch (Exception ex)
            {
                log.Error("Ошибка в методе обновления: "+ex);
            }
            return true;
        }




        public bool UpdateUser(User st)
        {

            try
            {
                var Entity = entities.User.FirstOrDefault(x => x.Id == st.Id);
                Entity.Login = st.Login;
                Entity.Password = st.Password;
                Entity.Surname = st.Surname;
                Entity.Name = st.Name;
                Entity.Patronymic = st.Patronymic;
                Entity.Post = st.Post;
                Entity.n_per_file = st.n_per_file;
                Entity.Id_shop = st.Id_shop;
                Entity.Salary = st.Salary;
                Entity.Id_role = st.Id_role;
                entities.SaveChanges();
                log.Debug("Запрос на изменение прошел успешно ");
            }
            catch (SEHException ex)
            {
                log.Error("Ошибка в методе обновления: " + ex);
            }
            return true;
        }



        public bool DeleteUser(int id)
        {
            try
            {
                User originalUs = GetUser(id);
                entities.User.Remove(originalUs);
                entities.SaveChanges();
                log.Debug("Запрос на удаление прошел успешно ");
            }
            catch(Exception ex)
            {
                log.Error("Ошибка в методе удаления: " + ex);
            }
            return true;


        }

    }
}