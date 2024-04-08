using System.ComponentModel.DataAnnotations;

namespace CustomerManagementService.Domain.Models
{
    public class CustomerModel : IComparable<CustomerModel>, IEquatable<CustomerModel>
    {
        public int Id { get; set; }

        public int Age { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int CompareTo(CustomerModel other)
        {
            if (other is null)
            {
                return 1;
            }

            if (LastName == other.LastName)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);
        }

        // Compare to null is allowed

        public bool Equals(CustomerModel other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            CustomerModel customer = obj as CustomerModel;
            if (customer is null)
            {
                return false;
            }
            return Equals(customer);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(CustomerModel left, CustomerModel right)
        {
            if (((object)left) == null || ((object)right) == null) 
            {
                return Equals(left, right);
            }

            return left.Equals(right);
        }

        public static bool operator !=(CustomerModel left, CustomerModel right)
        {
            if (((object)left) == null || ((object)right) == null)
            {
                return !Equals(left, right);
            }

            return !left.Equals(right);
        }
        
        public static bool operator >(CustomerModel operand1, CustomerModel operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        public static bool operator <(CustomerModel operand1, CustomerModel operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        public static bool operator >=(CustomerModel operand1, CustomerModel operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        public static bool operator <=(CustomerModel operand1, CustomerModel operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        public override string ToString()
        {
            return $"LastName: {LastName} FirstName: {FirstName} Age: {Age} Id: {Id}";
        }
    }
}
