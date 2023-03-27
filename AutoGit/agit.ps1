$diff = Invoke-Expression "git diff"

if ($diff -eq "") {
    Write-Host "No changes to commit"
    return 0
}

$OPENAI_API_KEY = Get-Content -Path "/Users/nyvall/Code/Simon-Utility/AutoGit/chatGPTConnectionString.txt" -Raw

$uri = "https://api.openai.com/v1/completions"
$headers = @{
    "Content-Type" = "application/json"
    "Authorization" = "Bearer $OPENAI_API_KEY"
}

$body = @{
    "model" = "text-davinci-003"
    "prompt" = "Generate the commit message for the following diff: $diff"
    "max_tokens" = 1000
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri $uri -Method Post -Headers $headers -Body $body


Write-Host "The following message was generated: " + $response.choices[0].text
Write-Host "Do you want to commit with this message? (y/n)"

$answer = Read-Host

if ($answer -eq "y") {
    git commit -m $response.choices[0].text
    Write-Host "Commit successful"
} else {
    Write-Host "Commit aborted"
}