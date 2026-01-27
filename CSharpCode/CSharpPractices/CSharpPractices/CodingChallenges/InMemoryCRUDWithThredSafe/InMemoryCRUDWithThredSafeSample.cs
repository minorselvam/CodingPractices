using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.InMemoryCRUDWithThredSafe
{
    public class InMemoryCRUDWithThredSafeSample
    {
        List<StudentRecord> lstStudent = new List<StudentRecord>();
        object _lockObject = new();

        //Create
        public void CreateRecord(StudentRecord stuRecord)
        {
            lock(_lockObject)
            {
                if(stuRecord.studentID == 0)
                {
                    if(lstStudent.Count == 0)
                    {
                        stuRecord.studentID = 1;
                    }
                    else
                    {
                        stuRecord.studentID = lstStudent.Max(r=> r.studentID+1);
                    }
                   lstStudent.Add(stuRecord);
                }
            }
        }

        //Update
        public bool UpdateRecord(int stutendID, string studentName)
        {
            lock (_lockObject)
            {
                var record = lstStudent.Where(s=> s.studentID == stutendID).FirstOrDefault();
                if (record == null)
                {
                    return false;
                }
                record.studentName = studentName;
                return true;
            }
        }

        //Delete
        public bool DeleteRecord(int stutendID)
        {
            lock(_lockObject)
            {
                var record = lstStudent.Where(s=> s.studentID==stutendID).FirstOrDefault(); ;
                if (record == null) 
                { 
                    return false; 
                }
                
                lstStudent.Remove(record);
                return true;
            }
        }

        public StudentRecord? GetById(int studentID)
        {
            lock(_lockObject)
            {
                return lstStudent.Where(s=> s.studentID==studentID).FirstOrDefault();
            }
        }

        public void DisplayStudentInfoById(int studentID)
        {
            StudentRecord? stuRecord = GetById(studentID);
            if (stuRecord == null)
            {
                Console.WriteLine("No record exists");
                return;
            }

            Console.WriteLine("ID: " + stuRecord.studentID + Environment.NewLine + "Name: " + stuRecord.studentName + Environment.NewLine);
        }

        public void DisplayAllRecords()
        {
            List<StudentRecord>? stuList = GetAllRecords();
            if(stuList==null)
            {
                Console.WriteLine("No record exists");
                return;
            }

            foreach (StudentRecord stuRecord in stuList)
            {
                Console.WriteLine("ID: " + stuRecord.studentID + Environment.NewLine + "Name: " + stuRecord.studentName + Environment.NewLine);
            }
        }

        public List<StudentRecord> GetAllRecords()
        {
            return lstStudent.ToList();
        }
    }

    public class StudentRecord
    {
        public int studentID { get; set; }
        public string? studentName { get; set; }
     }
}
