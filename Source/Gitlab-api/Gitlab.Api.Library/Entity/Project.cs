#region Apache License
//
// Licensed to the Apache Software Foundation (ASF) under one or more 
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership. 
// The ASF licenses this file to you under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with 
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

namespace Gitlab
{
    using System;

    /// <summary>
    /// プロジェクトクラス
    /// </summary>
    public class Project
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Path_with_namespace { get; set; }
        public string Default_branch { get; set; }
        public bool Private { get; set; }
        public bool Issues_enabled { get; set; }
        public bool Merge_requests_enabled { get; set; }
        public bool Wall_enabled { get; set; }
        public bool Wiki_enabled { get; set; }
        public DateTime Created_at { get; set; }
        public Owner Owner { get; set; }
    }
}
