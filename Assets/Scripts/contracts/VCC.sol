// https://ethereum.org/en/developers/tutorials/understand-the-erc-20-token-smart-contract/
// https://www.geeksforgeeks.org/solidity-programming-erc-20-token/
// Compatible with version of compiler upto 0.6.6 (outdated, had to change)
pragma solidity >=0.7.0 <0.9.0;

// ERC-20 interface
interface IERC20
{
    function totalSupply() external view returns (uint256);
    function balanceOf(address account) external view returns (uint256);
    function allowance(address owner, address spender) external view returns (uint256);

    function transfer(address recipient, uint256 amount) external returns (bool);
    function approve(address spender, uint256 amount) external returns (bool);
    function transferFrom(address sender, address recipient, uint256 amount) external returns (bool);

    event Approval(address indexed owner, address indexed spender, uint256 value);
    event Transfer(address indexed from, address indexed to, uint256 value);
}

// Creating a Contract
contract VCC is IERC20
{
    // Token settings
    string public constant name = "Victor Capital Coin";
    string public constant symbol = "VCC";
    uint8 public constant decimals = 18;

    // Variables 
    mapping(address => uint256) balances; // Table to map addresses to their balance
    mapping(address => mapping(address => uint256)) allowed; // Mapping owner address to those who are allowed to use the contract
    uint256 totalSupply_; // totalSupply

    // Constructor
    // Initialize the contract. Supply is set and given to the contract deployer
    constructor(uint256 totalSupplyToSet) {
        totalSupply_ = totalSupplyToSet;
        balances[msg.sender] = totalSupply_;
    }

    // Getters
    // totalSupply function returns the total supply of tokens in existence
    // 1 token will be returned as 1000000000000000000?? I think
    function totalSupply() public override view returns (uint256 theSupply)
    {
        return totalSupply_;
    }

    // balanceOf function returns the amount of tokens owned by an address
    function balanceOf(address owner) public override view returns (uint256 balance)
    {
        return balances[owner];
    }

    // Check if address is allowed to spend on the owner's behalf
    function allowance(address owner, address spender) public override view returns (uint256 remaining)
    {
        return allowed[owner][spender];
    }

    // Functions
    // transfer function. Moves the amount of tokens from the function caller address (msg.sender)
    // to recipient address. 
    // This function emits the Transfer event and returns true if success
    function transfer(address recipient, uint256 amount) public override returns (bool success)
    {
        // transfers the value if balance of sender is greater than the amount
        if (balances[msg.sender] >= amount)
        {
            balances[msg.sender] -= amount;
            balances[recipient] += amount;

            // Fire a transfer event for any logic that is listening
            emit Transfer(msg.sender, recipient, amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    // function approve. Set the amount of allowance the spender address is allowed to transfer from the function
    // caller (msg.sender). This function emits the Approval event and returns true if successful.
    function approve(address spender, uint256 amount) public override returns (bool success)
    {
        // If the address is allowed to spend from this contract
        allowed[msg.sender][spender] = amount;

        // Fire the event "Approval" to execute any logic that was listening to it
        emit Approval(msg.sender, spender, amount);
        return true;
    }

    // Moves the amount of tokens from the sender to recipient address using the allowance mechanism. 
    // Amount is deducted from caller's allowance. 
    function transferFrom(address sender, address recipient, uint256 amount) public override returns (bool success)
    {
        if (balances[sender] >= amount && allowed[sender][msg.sender] >= amount
        && amount > 0 && balances[recipient] + amount > balances[recipient])
        {
            balances[sender] -= amount;
            balances[recipient] += amount;

            // Fire a Transfer event for any logic that is listening
            emit Transfer(sender, recipient, amount);
            return true;
        }
        else
        {
            return false;
        }
    }

}
    
