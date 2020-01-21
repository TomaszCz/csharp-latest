namespace csharp_latest._8._0
{
    #region Switch expressions
    class Bank
    {
        public BankBranchStatus Status { get; set; }
    }

    enum BankBranchStatus
    {
        Open,
        Closed,
        VIPCustomersOnly
    }

    class SwitchExpressions
    {
        // classic :
        static bool CheckIfCanWalkIntoBankSwitch(Bank bank, bool isVip)
        {
            bool result = false;

            switch (bank.Status)
            {
                case BankBranchStatus.Open:
                    result = true;
                    break;

                case BankBranchStatus.Closed:
                    result = false;
                    break;

                case BankBranchStatus.VIPCustomersOnly:
                    result = isVip;
                    break;
            }

            return result;
        }

        // modern terse syntax :
        static bool CheckIfCanWalkIntoBank(Bank bank, bool isVip)
        {
            return bank.Status switch
            {
                BankBranchStatus.Open => true,
                BankBranchStatus.Closed => false,
                BankBranchStatus.VIPCustomersOnly when isVip => true,
                BankBranchStatus.VIPCustomersOnly when !isVip => false,
                _ => false
            };
        }

        static bool CheckIfCanWalkIntoBankTuple(Bank bank, bool isVip)
        {
            return (bank.Status, isVip) switch
            {
                (BankBranchStatus.Open, _) => true,
                (BankBranchStatus.Closed, _) => false,
                (BankBranchStatus.VIPCustomersOnly, true) => true,
                (BankBranchStatus.VIPCustomersOnly, false) => false,
                _ => false
            };
        }

        static bool CheckIfCanWalkIntoBankPassingObjects(Bank bank, bool isVip)
        {
            return bank switch
            {
                { Status: BankBranchStatus.Open } => true,
                { Status: BankBranchStatus.Closed } => false,
                { Status: BankBranchStatus.VIPCustomersOnly } => isVip,
                _ => false
            };
        }

    }
    #endregion
}
