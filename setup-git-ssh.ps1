# Git SSH Setup Script for Windows PowerShell (Local Repository Only)

Write-Host "Starting Git SSH configuration for local repository..." -ForegroundColor Cyan

# 1. Start SSH agent
Write-Host "`n[1/5] Starting SSH agent..." -ForegroundColor Yellow
$sshAgent = ssh-agent
Invoke-Expression $sshAgent

# 2. Add SSH private key
Write-Host "[2/5] Adding SSH private key..." -ForegroundColor Yellow
ssh-add $env:USERPROFILE\.ssh\id_rsa_own_github

# 3. Configure Git user name (local to this repository)
Write-Host "[3/5] Configuring Git user name (local)..." -ForegroundColor Yellow
git config --local user.name "subhamoy-burman"

# 4. Configure Git email (local to this repository)
Write-Host "[4/5] Configuring Git email (local)..." -ForegroundColor Yellow
git config --local user.email "subhamoy.2.burman@gmail.com"

# 5. Test GitHub SSH authentication
Write-Host "[5/5] Testing GitHub SSH authentication..." -ForegroundColor Yellow
ssh -T git@github.com

Write-Host "`nGit SSH setup complete for this repository!" -ForegroundColor Green
