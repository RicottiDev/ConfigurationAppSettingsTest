using ConfigurationAppSettingsTest.BindConfigurations;
using ConfigurationAppSettingsTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationAppSettingsTest.Controllers
{
    public class ConfigurationTestController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IOptions<Level1> _options;
        private readonly IOptionsSnapshot<Level1> _optionSnapshot;
        private readonly IOptionsMonitor<Level1> _optionMonitor;
        public ConfigurationTestController(IConfiguration configuration,
                                           IOptions <Level1> options,
                                           IOptionsSnapshot<Level1> optionsSnapshot,
                                           IOptionsMonitor<Level1> optionsMonitor)
        {
            _configuration = configuration;
            _options = options;
            _optionSnapshot = optionsSnapshot;
            _optionMonitor = optionsMonitor;
        }

        [HttpGet("GetValue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetValue()
        {
            var value = _configuration.GetValue<string>("Level1:Level2:Level2String");
            return Ok(value);
        }

        [HttpGet("BindConfiguration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BindConfiguration()
        {
            Level1BindConfiguration level1BindConfiguration = new Level1BindConfiguration();
            var value = level1BindConfiguration.BindConfiguration(_configuration);
            return Ok(value);
        }

        //Get the options when the application is started
        [HttpGet("OptionPattern")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult OptionPattern()
        {
            var value = _options.Value.Level2.Level2Int;
            return Ok(value);
        }

        //Get the options when the application makes a request
        [HttpGet("OptionPatternSnapshot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult OptionPatternSnapshot()
        {
            var value = _optionSnapshot.Value.Level2.Level2Int;
            return Ok(value);
        }

        //Get the current options
        [HttpGet("OptionPatternMonitor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult OptionPatternMonitor()
        {
            var value = _optionMonitor.CurrentValue.Level2.Level2Int;
            return Ok(value);
        }
    }
}
