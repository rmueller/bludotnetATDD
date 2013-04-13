# Setup variables
$root = $pwd
$FeatureDirectory = "$root\BluDotNet.Dominio.Testes\Features"
$OutputDirectory = "$root\docs"
$DocumentationFormat = "html"
$SystemUnderTestName = "Software BlutDotNet"
$SystemUnderTestVersion = "1.3.42"
$TestResultsFormat = "nunit"
Import-Module .\libs\Pickles.0.8.0.0\tools\PicklesDoc.Pickles.PowerShell.dll
 
# Call pickles
Pickle-Features -FeatureDirectory $FeatureDirectory  `
                -OutputDirectory $OutputDirectory  `
				-Language "pt-BR" `
                -DocumentationFormat $DocumentationFormat `
                -SystemUnderTestName $SystemUnderTestName  `
                -SystemUnderTestVersion $SystemUnderTestVersion  `
                -TestResultsFormat $TestResultsFormat  `
                -TestResultsFile $TestResultsFile