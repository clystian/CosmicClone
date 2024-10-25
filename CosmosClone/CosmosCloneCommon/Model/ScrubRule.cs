﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CosmosCloneCommon.Model
{
    public class ScrubRule
    {
        public int RuleId { get; set; }
        public string FilterCondition { get; set; }
        public string PropertyName { get; set; }
        public string FindValue { get; set; }
        public string UpdateValue { get; set; }        

        public RuleType? Type { get; set; }

        public long RecordsByFilter { get; set; }
        public long RecordsUpdated { get; set; }
        private long CountNullAttributes { get; set; }
        public bool IsComplete { get; set; }

        public ScrubRule() { }
        public ScrubRule(string filterCondition, string propertyName, RuleType type, string updateValue, int ruleId)
        {

            this.FilterCondition = filterCondition;
            this.PropertyName = propertyName;
            this.UpdateValue = updateValue;
            this.Type = type;
            this.RuleId = ruleId;
            this.IsComplete = false;
        }

    }

    public enum RuleType { SingleValue, NullValue, Shuffle, PartialMaskFromLeft, PartialMaskFromRight, FindAndReplace };//Can add random rule type later if required.     
}