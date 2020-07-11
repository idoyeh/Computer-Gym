using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DTO;
using ClassLibrary.EF;


namespace ClassLibrary.DbClasses
{

    public class TrainerExtension
    {
        // DataBaseConnection.

        //מתודה להחזרת שם משתמש וסיסמא כדי לאמת התחברות של מאמן
        //אם לא קיים מחזיר null
        public static TrainerIdAndPasswordDTO GetTrainerIdAndPassword(string trainer_id)
        {
            ComputerGymDBContext db = new ComputerGymDBContext();
            return db.Trainers.Select(x => new TrainerIdAndPasswordDTO()
            {
                Password = x.Password,
                Trainer_Id = x.Trainer_Id,
            }).SingleOrDefault(x => x.Trainer_Id == trainer_id);
        }


        //מתודה להחזרת פרטים של מאמן כדי להציגם בדף שלו
        //אם לא קיים מחזיר null
        public static TrainerDTO GetTrainer(string trainer_id)
        {
            ComputerGymDBContext db = new ComputerGymDBContext();
            return db.Trainers.Select(x => new TrainerDTO()
            {
                Trainer_Id = x.Trainer_Id,
                First_Name = x.First_Name,
                Last_Name = x.Last_Name,
                User_Name = x.User_Name,
                Password = x.Password,
                Phone_Number = x.Phone_Number,
            }).SingleOrDefault(x => x.Trainer_Id == trainer_id);

        }


        //מתודה להוספת מאמן חדש
        public static bool AddTrainer(Trainer trainer)
        {
            ComputerGymDBContext db = new ComputerGymDBContext();

            Trainer trainerToAdd = new Trainer();
            trainerToAdd.Trainer_Id = trainer.Trainer_Id;
            trainerToAdd.First_Name = trainer.First_Name;
            trainerToAdd.Last_Name = trainer.Last_Name;
            trainerToAdd.User_Name = trainer.User_Name;
            trainerToAdd.Password = trainer.Password;
            trainerToAdd.Phone_Number = trainer.Phone_Number;

            try
            {
                db.Trainers.Add(trainerToAdd);
                db.SaveChanges();
            }
            catch (Exception)
            {

               return false;
            }

            try
            {

            }
            catch (Exception)
            {

                throw;
            }


            return true;
        }


        //מתודה לעידכון פרטים של מאמן        
        public static bool UpdateTrainer(Trainer trainer)
        {
            ComputerGymDBContext db=new ComputerGymDBContext();
            Trainer trainerToUpdate = db.Trainers.SingleOrDefault(x => x.Trainer_Id == trainer.Trainer_Id);
            
            if (trainerToUpdate == null)
            {
                return false;
            }

            else if (trainerToUpdate != null)
            {
                trainerToUpdate.First_Name = trainer.First_Name;
                trainerToUpdate.Last_Name = trainer.Last_Name;
                trainerToUpdate.User_Name = trainer.User_Name;
                trainerToUpdate.Password = trainer.Password;
                trainerToUpdate.Phone_Number = trainer.Phone_Number;
                try
                {
                db.SaveChanges();
                return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            return false;
        }



    }
}
