﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;


public partial class AllowanceFunction : AllowanceFunctionBase
{
}

[Function("allowance", "uint256")]
public class AllowanceFunctionBase : FunctionMessage
{
	[Parameter("address", "owner", 1)] public virtual string Owner { get; set; }
	[Parameter("address", "spender", 2)] public virtual string Spender { get; set; }
}

public partial class ApproveFunction : ApproveFunctionBase
{
}

[Function("approve", "bool")]
public class ApproveFunctionBase : FunctionMessage
{
	[Parameter("address", "spender", 1)] public virtual string Spender { get; set; }
	[Parameter("uint256", "amount", 2)] public virtual BigInteger Amount { get; set; }
}

public partial class BalanceOfFunction : BalanceOfFunctionBase
{
}

[Function("balanceOf", "uint256")]
public class BalanceOfFunctionBase : FunctionMessage
{
	[Parameter("address", "owner", 1)] public virtual string Owner { get; set; }
}

public partial class DecimalsFunction : DecimalsFunctionBase
{
}

[Function("decimals", "uint8")]
public class DecimalsFunctionBase : FunctionMessage
{
}

public partial class GetDeployerFunction : GetDeployerFunctionBase
{
}

[Function("getDeployer", "address")]
public class GetDeployerFunctionBase : FunctionMessage
{
}

public partial class NameFunction : NameFunctionBase
{
}

[Function("name", "string")]
public class NameFunctionBase : FunctionMessage
{
}

public partial class SymbolFunction : SymbolFunctionBase
{
}

[Function("symbol", "string")]
public class SymbolFunctionBase : FunctionMessage
{
}

public partial class TotalSupplyFunction : TotalSupplyFunctionBase
{
}

[Function("totalSupply", "uint256")]
public class TotalSupplyFunctionBase : FunctionMessage
{
}

public partial class TransferFunction : TransferFunctionBase
{
}

[Function("transfer", "bool")]
public class TransferFunctionBase : FunctionMessage
{
	[Parameter("address", "recipient", 1)] public virtual string Recipient { get; set; }
	[Parameter("uint256", "amount", 2)] public virtual BigInteger Amount { get; set; }
}

public partial class TransferFromFunction : TransferFromFunctionBase
{
}

[Function("transferFrom", "bool")]
public class TransferFromFunctionBase : FunctionMessage
{
	[Parameter("address", "sender", 1)] public virtual string Sender { get; set; }
	[Parameter("address", "recipient", 2)] public virtual string Recipient { get; set; }
	[Parameter("uint256", "amount", 3)] public virtual BigInteger Amount { get; set; }
}

public partial class ApprovalEventDTO : ApprovalEventDTOBase
{
}

[Event("Approval")]
public class ApprovalEventDTOBase : IEventDTO
{
	[Parameter("address", "owner", 1, true)]
	public virtual string Owner { get; set; }

	[Parameter("address", "spender", 2, true)]
	public virtual string Spender { get; set; }

	[Parameter("uint256", "value", 3, false)]
	public virtual BigInteger Value { get; set; }
}

public partial class TransferEventDTO : TransferEventDTOBase
{
}

[Event("Transfer")]
public class TransferEventDTOBase : IEventDTO
{
	[Parameter("address", "from", 1, true)]
	public virtual string From { get; set; }

	[Parameter("address", "to", 2, true)] public virtual string To { get; set; }

	[Parameter("uint256", "value", 3, false)]
	public virtual BigInteger Value { get; set; }
}

public partial class AllowanceOutputDTO : AllowanceOutputDTOBase
{
}

[FunctionOutput]
public class AllowanceOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("uint256", "remaining", 1)] public virtual BigInteger Remaining { get; set; }
}


public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase
{
}

[FunctionOutput]
public class BalanceOfOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("uint256", "balance", 1)] public virtual BigInteger Balance { get; set; }
}

public partial class DecimalsOutputDTO : DecimalsOutputDTOBase
{
}

[FunctionOutput]
public class DecimalsOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("uint8", "", 1)] public virtual byte ReturnValue1 { get; set; }
}

public partial class GetDeployerOutputDTO : GetDeployerOutputDTOBase
{
}

[FunctionOutput]
public class GetDeployerOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("address", "theDeployer", 1)]
	public virtual string TheDeployer { get; set; }
}

public partial class NameOutputDTO : NameOutputDTOBase
{
}

[FunctionOutput]
public class NameOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("string", "", 1)] public virtual string ReturnValue1 { get; set; }
}

public partial class SymbolOutputDTO : SymbolOutputDTOBase
{
}

[FunctionOutput]
public class SymbolOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("string", "", 1)] public virtual string ReturnValue1 { get; set; }
}

public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase
{
}

[FunctionOutput]
public class TotalSupplyOutputDTOBase : IFunctionOutputDTO
{
	[Parameter("uint256", "theSupply", 1)] public virtual BigInteger TheSupply { get; set; }
}