using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

Console.Write("Cole a URL do YouTube: ");
string url = Console.ReadLine()!;
if (string.IsNullOrEmpty(url))
{
    Console.WriteLine("URL inválida.");
    return 1;
}

// Caminho da pasta onde estão yt-dlp.exe e ffmpeg.exe
string patchPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Patch");
string fullPath = Path.GetFullPath(patchPath);

string ytdlpPath = Path.Combine(fullPath, "yt-dlp.exe");
string ffmpegPath = Path.Combine(fullPath, "ffmpeg.exe");

if (!File.Exists(ytdlpPath) || !File.Exists(ffmpegPath))
{
    Console.WriteLine("❌ yt-dlp.exe ou ffmpeg.exe não encontrados na pasta Patch.");
    return 1;
}

// Pasta de saída
string outputDir = Path.Combine(Environment.CurrentDirectory, "downloads");
Directory.CreateDirectory(outputDir);

// Nome do arquivo de saída
string outputTemplate = Path.Combine(outputDir, "%(title)s.%(ext)s");

// Argumentos do yt-dlp
// Corrigindo barras no Windows
string ffmpegFolder = fullPath.TrimEnd('\\'); // remove barra final se houver

string arguments = $"-f bestvideo+bestaudio --merge-output-format mp4 --ffmpeg-location \"{ffmpegFolder}\" -o \"{outputTemplate}\" \"{url}\" --newline";

var psi = new ProcessStartInfo
{
    FileName = ytdlpPath,
    Arguments = arguments,
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

var process = new Process { StartInfo = psi, EnableRaisingEvents = true };

process.OutputDataReceived += (sender, e) =>
{
    if (string.IsNullOrWhiteSpace(e.Data)) return;
    string line = e.Data.Trim();

    // Processa somente linhas de download
    if (!line.StartsWith("[download]")) return;

    // Regex flexível para pegar percentual, velocidade e ETA
    var progressRegex = new Regex(@"\[download\].*?(?<percent>\d{1,3}(?:\.\d+)?)%.*?(at\s+(?<speed>[^\s]+))?.*?(ETA\s+(?<eta>[^\s]+))?", RegexOptions.Compiled);
    var match = progressRegex.Match(line);

    if (match.Success && decimal.TryParse(match.Groups["percent"].Value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal percent))
    {
        string speed = match.Groups["speed"].Success ? match.Groups["speed"].Value : "N/A";
        string eta = match.Groups["eta"].Success ? match.Groups["eta"].Value : "N/A";

        int barWidth = 40;
        int pos = (int)(percent / 100 * barWidth);

        // Garante que pos fique entre 0 e barWidth
        pos = Math.Max(0, Math.Min(barWidth, pos));

        // Também garante que percent não passe de 100
        decimal displayPercent = Math.Min(percent, 100);

        string bar = new string('=', pos) + new string(' ', barWidth - pos);
        Console.Write($"\r[{bar}] {displayPercent:0.0}% | {speed} | ETA {eta}");
    }
};


process.ErrorDataReceived += (sender, e) =>
{
    //if (!string.IsNullOrEmpty(e.Data))
    //{
    //    Console.WriteLine("[STDERR] " + e.Data);
    //}
};

try
{
    Console.WriteLine("---------------------------------Iniciando download---------------------------------");
    process.Start();
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();

    await Task.Run(() => process.WaitForExit());

    Console.WriteLine(); // pular linha depois do progresso
    if (process.ExitCode == 0)
    {
        Console.WriteLine("---------------------------------Download concluído!---------------------------------");
        var files = Directory.GetFiles(outputDir);
        Console.WriteLine("Arquivos na pasta de saída:");
        foreach (var f in files) Console.WriteLine(" - " + Path.GetFileName(f));
    }
    else
    {
        Console.WriteLine($"❌ yt-dlp terminou com código {process.ExitCode}.");
    }

    return process.ExitCode;
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao executar yt-dlp: " + ex.Message);
    return 2;
}