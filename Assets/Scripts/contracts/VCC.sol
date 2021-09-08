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
    uint256 totalSupply; // totalSupply
    
    /*
     *  Constructor
     *
     *  Initialize the contract. Supply is set and given to the contract deployer
     */
    constructor(uint256 total) public {
        totalSupply = total;
        balances[msg.sender] = totalSupply;
    }

    // Getters
    /*
    *   totalSupply function. Returns the total supply of tokens in existence
    *   Returns the amount of tokens in existence. This function is a getter and does not modify the state of the contract. Keep in mind that there is no floats in Solidity. Therefore most tokens adopt 18 decimals and will return the total supply and other results as followed 1000000000000000000 for 1 token. Not every tokens has 18 decimals and this is something you really need to watch for when dealing with tokens.
    */
    function totalSupply() public view returns (uint256 theTotalSupply)
    {
        theTotalSupply = totalSupply;
        return theTotalSupply;
    }

    // balanceOf function
    function balanceOf(address owner) public view returns (uint256 balance)
    {
        return balances[owner];
    }

    // Check if address is allowed to spend on the owner's behalf
    function allowance(address _owner, address _spender) public view returns (uint256 remaining)
    {
        return allowed[_owner][_spender];
    }

    // function approve
    function approve(address _spender, uint256 _amount) public returns (bool success)
    {
        // If the address is allowed to spend from this contract
        allowed[msg.sender][_spender] = _amount;

        // Fire the event "Approval" to execute any logic that was listening to it
        emit Approval(msg.sender, _spender, _amount);
        return true;
    }

    // transfer function
    function transfer(address _to, uint256 _amount) public returns (bool success)
    {
        // transfers the value if balance of sender is greater than the amount
        if (balances[msg.sender] >= _amount)
        {
            balances[msg.sender] -= _amount;
            balances[_to] += _amount;

            // Fire a transfer event for any logic that is listening
            emit Transfer(msg.sender, _to, _amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    /* The transferFrom method is used for a withdraw workflow, allowing contracts to send tokens on your behalf, 
    *  for example to  "deposit" to a contract address and/or to charge fees in sub-currencies;
    */
    function transferFrom(address _from, address _to, uint256 _amount)
    public returns (bool success)
    {
        if (balances[_from] >= _amount && allowed[_from][msg.sender] >= _amount && _amount > 0 && balances[_to] + _amount > balances[_to])
        {
            balances[_from] -= _amount;
            balances[_to] += _amount;

            // Fire a Transfer event for any logic that is listening
            emit Transfer(_from, _to, _amount);
            return true;
        }
        else
        {
            return false;
        }
    }


}
    
