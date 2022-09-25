namespace Algorithms.Datatypes
{
    public class Node<T>
    {
        #region Members
        private T value;

        public T Value
        {
            get => value;
            set => this.value = value;
        }
        #endregion

        #region Constructors
        public Node(T value)
        {
            this.value = value;
        }
        #endregion

        #region MemberFunctions

        #endregion
    }
}
