﻿using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Dietary.DataAccess;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;
using Dietary.DataAccess.Models.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Dietary.Base
{
    public class BaseController<
        ModelCreate,
        ModelUpdate,
        ModelDetail,
        TEntity>(IBaseService<TEntity> baseService) : ControllerBase
        where ModelCreate : BaseModel
        where ModelUpdate : BaseModel
        where ModelDetail : BaseModel, new()
        where TEntity : BaseEntity
    {
        protected IBaseService<TEntity> _baseService = baseService;

        [HttpPost]
        public virtual async Task<ActionResult> Create(ModelCreate model)
        {
            try
            {
                TEntity result = await _baseService.Create(model);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), result.Id);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult> Update(ModelUpdate model)
        {
            try
            {
                var result = await _baseService.Update(model);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), result.Id);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _baseService.Delete(id);

                return new SuccessApiResponse(string.Format(MessageConstant.Success), id);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ModelDetail>> GetById(Guid id)
        {
            try
            {
                ModelDetail model = await _baseService.Get<ModelDetail>(x => x.Id == id);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), model);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpGet("list")]
        public virtual ActionResult<List<ModelDetail>> GetList()
        {
            try
            {
                List<ModelDetail> models = _baseService.GetAll<ModelDetail>();
                return new SuccessApiResponse(string.Format(MessageConstant.Success), models);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }

    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value == null ? null :
                   Regex.Replace(value.ToString()!,
                   "([a-z])([A-Z])", "$1-$2",
                   RegexOptions.CultureInvariant,
                   TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
        }
    }
    public class BoolConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
    public class UtcDateTimeConverterHelper : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var stringValue = jsonDoc.RootElement.GetRawText().Trim('"').Trim('\'');
            var value = DateTime.Parse(stringValue, null, System.Globalization.DateTimeStyles.RoundtripKind);
            return value;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}

