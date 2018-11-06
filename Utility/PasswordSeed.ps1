param (
	[string]$Password
)

$salt = [System.Byte[]]::new(32)
$rng = [System.Random]::new()
$hmac = New-Object system.Security.Cryptography.HMACSHA256

$rng.NextBytes($salt)
$hmac.Key = $salt
$passwordBytes = [Text.Encoding]::UTF8.GetBytes($Password)
$hash = $hmac.ComputeHash($passwordBytes)
$saltString = [Convert]::ToBase64String($salt)
$hashString = [Convert]::ToBase64String($hash)

Write-Host "Password bytes: $passwordBytes" -Foreground Blue
Write-Host "Salt: $salt" -Foreground Green
Write-Host "Salt: $saltString" -Foreground Green
Write-Host "Hash: $hash" -Foreground Yellow
Write-Host "Hash: $hashString" -Foreground Yellow