﻿using EvilDICOM.Core;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIAnon.Anonymizers
{
    public class ProfileAnonymizer : IAnonymizer
    {
        public void Anonymize(DICOMObject d)
        {
            foreach (IDICOMElement elem in GenerateProfile())
            {
                d.Replace(elem);
            }
        }

        /// <summary>
        /// Returns a collection of identifiable elements
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public List<IDICOMElement> GenerateProfile()
        {
            List<IDICOMElement> profile = new List<IDICOMElement>();
           
            //PATIENT SEX
            profile.Add(GenerateEmptyDICOMString(TagHelper.PATIENT_SEX));

            //OTHER PATIENT IDS
            profile.Add(GenerateEmptyDICOMString(TagHelper.OTHER_PATIENT_IDS));

            //OTHER PATIENT NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.OTHER_PATIENT_NAMES));

            //ETHNIC GROUP
            profile.Add(GenerateEmptyDICOMString(TagHelper.ETHNIC_GROUP));

            //PATIENT COMMENTS
            profile.Add(GenerateEmptyDICOMString(TagHelper.PATIENT_COMMENTS));

            //REFERRING PHYSICIAN NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.REFERRING_PHYSICIAN_NAME));

            //ACCESSION NUMBER
            profile.Add(GenerateEmptyDICOMString(TagHelper.ACCESSION_NUMBER));

            //PHYSICIANS RECORD
            profile.Add(GenerateEmptyDICOMString(TagHelper.PHYSICIANS_OF_RECORD));

            //PHYSICIANS READING STUDY
            profile.Add(GenerateEmptyDICOMString(TagHelper.NAME_OF_PHYSICIANS_READING_STUDY));

            //ADMITTING DIAGNOSIS DESCRIPTION
            profile.Add(GenerateEmptyDICOMString(TagHelper.ADMITTING_DIAGNOSES_DESCRIPTION));

            //PATIENTS SIZE
            profile.Add(GenerateZeroDecimalString(TagHelper.PATIENT_SIZE));

            //PATIENTS WEIGHT
            profile.Add(GenerateZeroDecimalString(TagHelper.PATIENT_WEIGHT));

            //OCCUPATION
            profile.Add(GenerateEmptyDICOMString(TagHelper.OCCUPATION));

            //ADDITIONAL PATIENT HISTORY
            profile.Add(GenerateEmptyDICOMString(TagHelper.ADDITIONAL_PATIENT_HISTORY));

            //PERFORMING PHYSICIAN NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.PERFORMING_PHYSICIAN_NAME));

            //PROTOCOL NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.PROTOCOL_NAME));

            //SERIES DESCRIPTION
            profile.Add(GenerateEmptyDICOMString(TagHelper.SERIES_DESCRIPTION));

            //OPERATORS NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.OPERATORS_NAME));

            //INSTITUITION NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.INSTITUTION_NAME));

            //INSTITUTION ADDRESS
            profile.Add(GenerateEmptyDICOMString(TagHelper.INSTITUTION_ADDRESS));

            //STATION NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.STATION_NAME));

            //INSTITUTION DEPARTMENT NAME
            profile.Add(GenerateEmptyDICOMString(TagHelper.INSTITUTIONAL_DEPARTMENT_NAME));

            //DEVICE SERIAL NUMBER
            profile.Add(GenerateEmptyDICOMString(TagHelper.DEVICE_SERIAL_NUMBER));

            //DERIVATION DESCRIPTION
            profile.Add(GenerateEmptyDICOMString(TagHelper.DERIVATION_DESCRIPTION));

            //IMAGE COMMENTS
            profile.Add(GenerateEmptyDICOMString(TagHelper.IMAGE_COMMENTS));

            return profile;
        }

        private IDICOMElement GenerateZeroDecimalString(Tag tag)
        {
            DecimalString ds = new DecimalString(tag, new double[] { 0.0 });
            return ds;
        }

        private IDICOMElement GenerateEmptyDICOMString(Tag tag)
        {
            var s = new LongString();
            s.Tag = tag;
            s.Data = string.Empty;
            return s;
        }

        public string Name
        {
            get { return "DICOM Profile Anonymizer"; }
        }
    }
}
