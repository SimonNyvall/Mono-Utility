param(
    [string]$Url,
    [string]$Selector
)

$response = Invoke-WebRequest -Uri $Url

# Extract the specified information from the HTML content
$info = $response.ParsedHtml.querySelectorAll($Selector) | Select-Object -ExpandProperty innertext

Write-Host "$($info -join "`n")"

